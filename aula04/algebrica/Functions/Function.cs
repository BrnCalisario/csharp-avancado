using System;

namespace Algebra;

using Composition;

public abstract class Function
{
    public double this[double x] => get(x);

    protected abstract double get(double x);

    public abstract Function Derive();

    public static Function operator +(Function f, Function g)
    {
        Sum s = new Sum();
        s.Add(f);
        s.Add(g);
        return s;
    }

    public static Function operator +(Function f, double n)
    {
        Sum s = new Sum();
        s.Add(f);
        s.Add(new Constant(n));
        return s;
    }

    public static Function operator -(Function f, Function g)
    {
        Sub s = new Sub();
        s.Add(f);
        s.Add(g);
        return s;
    }

    public static Function operator -(Function f, double n)
    {
        Sub s = new Sub();
        s.Add(f);
        s.Add(new Constant(n));
        return s;
    }

    public static Function operator *(Function f, Function g)
    {
        Mult m = new Mult();
        m.Add(f);
        m.Add(g);
        return m;
    }

    public static Function operator *(Function f, double g)
    {
        Mult m = new Mult();
        m.Add(f);
        m.Add(new Constant(g));
        return m;
    }

    public static Function operator /(Function f, Function g)
    {
        Div d = new Div();
        d.Add(f);
        d.Add(g);
        return d;
    }

    public static Function operator /(Function f, double g)
    {
        Div d = new Div();
        d.Add(f);
        d.Add(new Constant(g));
        return d;
    }
}


