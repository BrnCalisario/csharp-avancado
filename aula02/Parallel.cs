using System;
using System.Collections.Concurrent;
using System.Linq;

Random rand =  new Random();

int N = 10_000;

monteCarlo();

void monteCarlo()
{
    int atkPoints = 0;
    int defPoints = 0;

    var start = DateTime.Now;
    for(int i = 0; i < N; i++)
    {
        var result = Round();
        atkPoints += result.atkResult ? 1 : 0;
        defPoints += result.defResult ? 1 : 0;
    }
    var end = DateTime.Now;

    System.Console.WriteLine(atkPoints);
    System.Console.WriteLine(defPoints);
    System.Console.WriteLine((end - start).Seconds);
}

(bool atkResult, bool defResult) Round()
{
    Team a = new Team() { rnd = rand, Quantity = 1000, _Side = Team.Side.Attack };
    Team b = new Team() { rnd = rand, Quantity = 765, _Side = Team.Side.Defense };

    while(a.Quantity > 1 && b.Quantity > 0)
    {
        a.Attack(b);
    }

    return (a.Quantity > 1, b.Quantity > 0);
}


public class Team
{
    public Random rnd { private get; set; }

    public int Quantity { get; set; }

    public Side _Side { get; set; }

    public enum Side { Attack, Defense }

    public void Attack(Team enemy)
    {
        int[] myDices = new int[3]; 
        int[] enemyDices = new int[3];

        for(int i = 0; i < 3; i++)
        {
            myDices[i] = roll();
            enemyDices[i] = roll();
        }
        
        myDices = myDices.OrderDescending().ToArray();
        enemyDices = enemyDices.OrderDescending().ToArray();

        int totalRounds = enemy.Quantity >= 3 ? 3 : enemy.Quantity;

        int myLoss = 0;
        int enemyLoss = 0;

        for(int i = 0; i < totalRounds; i++)
        {
            if(myDices[i] > enemyDices[i])
                enemyLoss++;
            else if(enemyDices[i] >= myDices[i])
                myLoss++;            
        }

        this.ReceiveDMG(myLoss);
        enemy.ReceiveDMG(enemyLoss);
    }

    public void ReceiveDMG(int qtd)
    {
        if(this._Side == Side.Attack)
            this.Quantity -= qtd == 3 ? 2 : qtd;
        else
            this.Quantity -= qtd;
    }

    int roll() 
        => this.rnd.Next(6) + 1;

}