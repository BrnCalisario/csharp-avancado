using System;
using System.Threading;
using System.Threading.Tasks;

class Programa
{
  public static void Main (string[] args)
  {
    const int attackers = 20;
    const int defenders = 20;
    const int poolSize = 22 * (attackers + defenders) / 10;
    int N = 100_000;
    Random rand = new Random();
    int attWin = 0;
    

    var start = DateTime.Now;
    Parallel.For(0, N, i =>
    {
      byte[] data = new byte[poolSize];
      lock (rand)
      {
        rand.NextBytes(data);
      }
      if (simulate(data))
        Interlocked.Add(ref attWin, 1);
    });
    var end = DateTime.Now;

    System.Console.WriteLine((end - start).Milliseconds);
   
    System.Console.WriteLine((double)attWin / N * 100);
    System.Console.WriteLine((double)(N - attWin) / N * 100);


    bool simulate(byte[] rnd)
    {
      int index = 0;
      int att = attackers;
      int def = defenders;

      while (true)
      {
        if (att < 2)
          return false;

        if (def < 1)
          return true;

        int attCount = att > 3 ? 3 : att - 1;
        int defCount = def > 2 ? 3 : def;
        int battles = attCount < defCount ? attCount : defCount;
        int defStart = index + attCount;

        Array.Sort(rnd, index, attCount);
        Array.Sort(rnd, defStart, defCount);

        for (int i = 0; i < battles; i++)
        {
          var attForce = rnd[index + attCount - 1 - i] / 42;
          var defForce = rnd[defStart + defCount - 1 - i] / 42;
          if (attForce > defForce) att--;
          else def--;
        }
      }
    }
  }
}