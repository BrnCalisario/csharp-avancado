using System;
using System.Linq;
using System.Collections.Generic;

namespace Algebra.Composition;

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

public class Mult : Composition
{
    protected override string symbol => "*";
    public override Function Derive()
    {
        Sum result = new Sum();

        for(int i = 0; i < this.funcs.Count; i++)
        {
            Mult m = new Mult();
            for(int j = 0; j < this.funcs.Count; j++)
            {
                if(i == j)
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
        if(this.funcs.Count == 1)
            return this.funcs.First()[x];

        double result = this.funcs.Select(f => f[x]).FirstOrDefault();

        foreach(Function f in this.funcs.Skip(1))
            result /= f[x];

        return result;
    }

    public override Function Derive()
    {
        Function v = funcs[funcs.Count()-1];
        Function u = new Div();
        foreach(var f in this.funcs.SkipLast())    
            
        (v * u.Derive() - v.Derive() * u) / Pow(v, 2);
    }
}