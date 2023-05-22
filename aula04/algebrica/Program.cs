using Algebra;
using Algebra.Composition;

using static Algebra.FunctionUtil;

Div d = new Div();

d.Add(x);
d.Add(x + 2);

System.Console.WriteLine(d.Derive()[2]);
System.Console.WriteLine(d.Derive());

