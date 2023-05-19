using Algebra;
using Algebra.Composition;

using static Algebra.FunctionUtil;

Mult m = new Mult();

m.Add(x);
m.Add(pow(x, 2));
m.Add(new Constant(2));

System.Console.WriteLine(m.Derive());

