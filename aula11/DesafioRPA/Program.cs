using System;
using System.Linq;
using System.Management.Automation;

RPA rpa = new RPA();
await rpa.Run();

// using var ps = PowerShell.Create();

// ps
//     .AddCommand("cd")
//     .AddArgument("C:\\Users\\disrct\\Desktop\\Repositorios\\Pasta2")
//     .Invoke();

// ps
//     .AddCommand("git")
//     .AddArgument("remote");

// var result = ps.Invoke();

// foreach (var v in result)
// {
//     System.Console.WriteLine(v);

// }