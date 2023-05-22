using System;
using System.Linq;
using System.Collections.Generic;

namespace Algebra.Composition;

using static FunctionUtil;


public class Sum : Composition
{
    protected override string symbol => "+";
    protected override double get(double x)
        => funcs.Select(f => f[x]).Sum();

    public override Function Derive()
    {
        Sum s = new Sum();

        foreach (var f in this.funcs)
            s.Add(f.Derive());

        return s;
    }
}

public class Sub : Composition
{
    protected override string symbol => "-";
    protected override double get(double x)
    {
        double result = this.funcs.FirstOrDefault()[x];

        foreach(var f in funcs.Skip(1))
            result -= f[x];

        return result;
    }

    public override Function Derive()
    {
        Sub s = new Sub();

        foreach(var f in this.funcs)
            s.Add(f);
        return s;
    }
}

public class Mult : Composition
{
    protected override string symbol => "*";
    public override Function Derive()
    {
        Sum result = new Sum();

        for (int i = 0; i < this.funcs.Count; i++)
        {
            Mult m = new Mult();
            for (int j = 0; j < this.funcs.Count; j++)
            {
                if (i == j)
                {
                    m.Add(this.funcs[j].Derive());
                    continue;
                }
                m.Add(this.funcs[j]);
            }
            result.Add(m);
        }

        return result;
    }

    protected override double get(double x)
    {
        double result = 1;

        foreach (var f in this.funcs)
            result *= f[x];

        return result;
    }
}

public class Div : Composition
{
    protected override string symbol => "/";

    protected override double get(double x)
    {
        if (this.funcs.Count == 1)
            return this.funcs.First()[x];

        double result = this.funcs.Select(f => f[x]).FirstOrDefault();

        foreach (Function f in this.funcs.Skip(1))
            result /= f[x];

        return result;
    }

    public override Function Derive()
    {
        if (this.funcs.Count() > 2)
        {
            Function v = funcs[funcs.Count() - 1];
            Div u = new Div();
            foreach (var f in this.funcs.SkipLast(1))
                u.Add(f);

            return ((v * u.Derive()) - (v.Derive() * u)) / pow(v, 2);
        }

        Function g = funcs[0];
        Function h = funcs[1];

        return ((h * g.Derive())- (h.Derive() * g)) / pow(h, 2);
    }
}