// using System;
// using System.Collections.Concurrent;
// using System.Collections.Generic;
// using System.Linq;

// // Atacante ganhou = def morre
// // Defesa ganhou ou empatou = ataque morre

// int N = 100_000;

// int battlesPerRound = 3;
// Random rand = new Random();
// int attackQtd = 1000;
// int defQtd = 750;


// int atkPoints = 0;
// int defPoints = 0;

// monteCarlo();


// void monteCarlo()
// {

//     var start = DateTime.Now;
//     for(int i = 0; i < N; i++)
//         Round();
//     var end = DateTime.Now;


//     Console.WriteLine("Ataque: " + (float)atkPoints/N * 100);
//     Console.WriteLine("Defesa: " + (float)defPoints/N * 100);

//     System.Console.WriteLine((end - start).Seconds);

// }


// void Round()
// {
//     int attack = attackQtd;
//     int def = defQtd;

//     int[] attackDices = new int[attack];
//     int[] defDices = new int[def];


//     for (int i = 0; i < attack; i++)
//     {
//         attackDices[i] = roll();
//     }

//     for (int i = 0; i < def; i++)
//     {
//         defDices[i] = roll();
//     }

//     int jump = 0;

//     while (attack > 1 && def > 0)
//     {
//         List<int> group1 = attackDices.Skip(jump).Take(3).OrderDescending().ToList();
//         List<int> group2 = defDices.Skip(jump).Take(3).OrderDescending().ToList();

//         int atkLoss = 0;
//         int defLoss = 0;

//         if (group1.Count < 3)
//             group2 = group2.Take(group1.Count).ToList();
//         else if (group2.Count < 3)
//             group1 = group2.Take(group2.Count).ToList();

//         jump += group1.Count();

//         if (jump >= attackDices.Count() || jump >= defDices.Count())
//             jump = 0;

//         for (int j = 0; j < group1.Count(); j++)
//         {
//             if (group1[j] > group2[j])
//                 defLoss++;
//             else if (group2[j] >= group1[j])
//                 atkLoss++;
//         }

//         attack -= atkLoss == battlesPerRound ? battlesPerRound - 1 : atkLoss;
//         def -= defLoss;
//     }

//     if(attack > 1)
//         atkPoints++;
//     else if(def > 0)
//         defPoints++;
// }


// int roll()
//     => rand.Next(6) + 1;

// using System;
// using System.Collections.Concurrent;
// using System.Collections.Generic;
// using System.Linq;

// // Atacante ganhou = def morre
// // Defesa ganhou ou empatou = ataque morre

// int N = 1_000;

// int battlesPerRound = 3;
// Random rand = new Random();
// int attackQtd = 1000;
// int defQtd = 500;


// int atkPoints = 0;
// int defPoints = 0;

// monteCarlo();


// void monteCarlo()
// {

//     var start = DateTime.Now;
//     for (int i = 0; i < N; i++)
//         Round();
//     var end = DateTime.Now;


//     Console.WriteLine("Ataque: " + (float)atkPoints / N * 100);
//     Console.WriteLine("Defesa: " + (float)defPoints / N * 100);

//     System.Console.WriteLine((end - start).Seconds);

// }


// void Round()
// {
//     int attack = attackQtd;
//     int def = defQtd;

//     ConcurrentQueue<int> attackDices = new ConcurrentQueue<int>();
//     ConcurrentQueue<int> defDices = new ConcurrentQueue<int>();


//     for (int i = 0; i < attack; i++)
//     {
//         attackDices.Enqueue(roll());
//     }

//     for (int i = 0; i < def; i++)
//     {
//         defDices.Enqueue(roll());
//     }

//     int jump = 0;

//     while ((attack > 1 && def > 0) && (attackDices.Count > 1 && defDices.Count > 0))
//     {
//         List<int> group1 = new List<int>();
//         List<int> group2 = new List<int>();

//         for (int i = 0; i < 3; i++)
//         {
//             if (attackDices.TryDequeue(out int v))
//             {
//                 group1.Add(v);
//             }

//             if (defDices.TryDequeue(out v))
//             {
//                 group2.Add(v);
//             }

//         }

//         int atkLoss = 0;
//         int defLoss = 0;

//         if (group1.Count < 3)
//             group2 = group2.Take(group1.Count).ToList();
//         else if (group2.Count < 3)
//             group1 = group2.Take(group2.Count).ToList();


//         if (jump >= attackDices.Count() || jump >= defDices.Count())
//             jump = 0;

//         for (int j = 0; j < group1.Count(); j++)
//         {
//             if (group1[j] > group2[j])
//                 defLoss++;
//             else if (group2[j] >= group1[j])
//                 atkLoss++;
//         }

//         attack -= atkLoss == battlesPerRound ? battlesPerRound - 1 : atkLoss;
//         def -= defLoss;

//     }

//     if (attack > 1 || attackDices.Count > 1)
//         atkPoints++;
//     else if (def > 0 || defDices.Count > 0)
//         defPoints++;
// }


// int roll()
//     => rand.Next(6) + 1;

