using System;

namespace Algebra;

using static FunctionUtil;

public abstract class Aggregation : Function
{
    protected Function inner;

    public Aggregation(Function f)
        => this.inner = f;

    protected abstract double calcule(Function f, double x);

    protected override double get(double x)
        => calcule(inner, x);
}

public class Cos : Aggregation
{
    public Cos(Function f) : base(f) { }

    protected override double calcule(Function f, double x)
        => Math.Cos(f[x]);

    public override Function Derive()
        => new Sin(inner);

    public override string ToString()
        => $"cos({inner})";
}

public class Sin : Aggregation
{
    public Sin(Function f) : base(f) { }

    protected override double calcule(Function f, double x)
        => Math.Sin(f[x]);

    public override Function Derive()
        => new Cos(inner);

    public override string ToString()
        => $"sin({inner})";
}

public class Ln : Aggregation
{
    public Ln(Function f) : base(f) { }

    protected override double calcule(Function f, double x)
        => Math.Log(f[x]);

    public override Function Derive()
        => x.Derive() / x;

    public override string ToString()
        => $"Ln({inner.ToString()})";

}

public class Pow : Aggregation
{   
    private Function expoent;

    public Pow(Function f, Function e) : base(f)
        => this.expoent = e;

    protected override double calcule(Function f, double x)
        => Math.Pow(f[x], expoent[x]);

    public override Function Derive()
        => pow(inner, expoent) * ln(inner) * expoent.Derive();

    public override string ToString()
        => $"{inner.ToString()}^{expoent.ToString()}";
}