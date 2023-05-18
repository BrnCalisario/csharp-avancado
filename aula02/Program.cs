// using System;
// using System.Collections.Concurrent;
// using System.Linq;
// using TeamOnTime;
// using TeamGenerated;

// using System.Threading;
// using System.Threading.Tasks;


// Random rand =  new Random();

// int N = 50_000;
// int atk = 1000;
// int def = 585;

// monteCarlo();

// void monteCarlo()
// {
//     int atkPoints = 0;
//     int defPoints = 0;

//     var start = DateTime.Now;
//     // Parallel.For(0, N, i => {
//     //     var result = Round();
//     //     atkPoints += result.atkResult ? 1 : 0;
//     //     defPoints += result.defResult ? 1 : 0;
//     // });

//     for(int i = 0; i < N; i++)
//     {
//         var result = Round();
//         atkPoints += result.atkResult ? 1 : 0;
//         defPoints += result.defResult ? 1 : 0;
//     }

//     var end = DateTime.Now;

//     System.Console.WriteLine("Ataque: " + (float)atkPoints / N * 100 + "%");
//     System.Console.WriteLine("Defesa: " + (float)defPoints / N * 100 + "%");
//     System.Console.WriteLine((end - start).Seconds + " segundo de execução");
// }

// (bool atkResult, bool defResult) Round()
// {
//     // Team a = new Team(rand, atk, Side.Attack);
//     // Team b = new Team(rand, def, Side.Defense);

//     Army a = new Army(rand, atk, Army.Side.Attack);
//     Army b = new Army(rand, def, Army.Side.Defense);

//     while(a.Quantity > 1 && b.Quantity > 0)
//     {
//         a.Attack(b);
//     }

//     return (a.Quantity > 1, b.Quantity > 0);
// }
