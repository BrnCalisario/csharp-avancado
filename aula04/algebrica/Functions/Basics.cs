using System;

namespace Algebra;

public class Linear : Function
{
    protected override double get(double x) => x;

    public override Function Derive()
        => new Constant(1);

   public override string ToString() => "x";
}

public class Constant : Function
{
    private double value;
    public Constant(double v)
        => this.value = v;

    protected override double get(double x)
        => this.value;

    public override Function Derive()
        => new Constant(0);

    public override string ToString() 
        => this.value.ToString();

}

