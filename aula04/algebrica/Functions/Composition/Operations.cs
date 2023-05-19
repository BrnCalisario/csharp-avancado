using System;
using System.Linq;


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
        throw new System.NotImplementedException();
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
        double result = this.funcs.Select(f => f[x]).FirstOrDefault();

        if(result == 0)
            return 0;

        foreach(Function f in this.funcs.Skip(1))
            result /= f[x];

        return result;
    }

    public override Function Derive()
    {
        throw new NotImplementedException();
    }
}