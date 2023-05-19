using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace TeamGenerated;

public class Army
{
    public Random rnd { private get; set; }

    public int Quantity { get; set; }

    public Side _Side { get; set; }

    public ConcurrentQueue<int> Dices { get; set; } = new ConcurrentQueue<int>();

    public bool hasLost()
        => 
        (this._Side is Side.Attack && this.Quantity <= 1)
        ||
        (this._Side is Side.Defense && this.Quantity <= 0);

    public enum Side { Attack, Defense }

    public Army(Random rnd, int qtd, Side side)
    {
        this.rnd = rnd;
        this.Quantity = qtd;
        this._Side = side;

        for (int i = 0; i < Quantity; i++)
            this.Dices.Enqueue(roll());
    }

    public void Attack(Army enemy)
    {
        if(this.hasLost() || enemy.hasLost())
            return;

        int matchQtd = 3;
        
        if(this.Quantity < 3)
            matchQtd = this.Quantity;
        else if (enemy.Quantity < 3)
            matchQtd = this.Quantity;

        int[] myDices = new int[matchQtd];
        int[] enemyDices = new int[matchQtd];

        for(int i = 0; i < matchQtd; i++)
        {
            this.Dices.TryDequeue(out int thisDice);
            myDices[i] = thisDice;

            enemy.Dices.TryDequeue(out int enemyDice);
            enemyDices[i] = enemyDice;
        }

        myDices = myDices.OrderDescending().ToArray();
        enemyDices = enemyDices.OrderDescending().ToArray();

        int atkPoints = 0;
        int defPoints = 0;

        for(int i = 0; i < matchQtd; i++)
        {
            if(myDices[i] > enemyDices[i])
                atkPoints++;
            else if(enemyDices[i] >= myDices[i])
                defPoints++;    
        }

        this.ReceiveDMG(defPoints);
        enemy.ReceiveDMG(atkPoints);
        
        // for(int i = 0; i < atkPoints; i++)
        //     lock(rnd)
        //         this.Dices.Enqueue(roll());
        
        // for(int i = 0; i < defPoints; i++)
        //     lock(rnd)
        //         enemy.Dices.Enqueue(roll());
        
        for(int i = 0; i < atkPoints; i++)
            this.Dices.Enqueue(roll());

        for(int i = 0; i < defPoints; i++)
            enemy.Dices.Enqueue(roll());
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