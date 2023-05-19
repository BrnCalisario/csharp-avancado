using System.Collections.Generic;

namespace Algebra.Composition;

public abstract class Composition : Function
{   
    protected abstract string symbol { get; }
    protected List<Function> funcs = new List<Function>();
    public IEnumerable<Function> InnerFunctions => funcs;

    public void Add(Function f)
        => this.funcs.Add(f);

    public override string ToString()
    {
        string str = "(";

        foreach(var f in this.funcs)
            str += f.ToString() + $" {symbol} ";
        
        return str.Substring(0, str.Length - 3) + ")";
    }
}

