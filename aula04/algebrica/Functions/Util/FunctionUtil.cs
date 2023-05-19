using System;

namespace Algebra;

// FlyWeigth + Facade
public static class FunctionUtil
{
    private static Linear linear = null;
    public static Function x
    {
        get
        {
            linear ??= new Linear();
            return linear;
        }
    }

    private static Constant euler = null;
    public static Function e
    {
        get
        {
            euler ??= new Constant(Math.E);
            return euler;
        }
    }

    public static Function sin(Function f)
        => new Sin(f);

    public static Function cos(Function f)
        => new Cos(f);

    public static Function pow(Function f, Function e)
        => new Pow(f, e);

    public static Function pow(Function f, double e)
        => new Pow(f, new Constant(e));

    public static Function ln(Function f)
        => new Ln(f);
}