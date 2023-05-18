using System;
using System.Collections.Concurrent;
using System.Linq;

namespace TeamOnTime;
public class Team
{
    public Random rnd { private get; set; }

    public int Quantity { get; set; }

    public Side _Side { get; set; }

    public bool hasLost()
        => 
        (this._Side is Side.Attack && this.Quantity <= 1)
        ||
        (this._Side is Side.Defense && this.Quantity <= 0);

    public Team(Random rnd, int qtd, Side side)
    {
        this.rnd = rnd;
        this.Quantity = qtd;
        this._Side = side;
    }

    public void Attack(Team enemy)
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
            myDices[i] = roll();
            enemyDices[i] = roll();
        }
        
        myDices = myDices.OrderDescending().ToArray();
        enemyDices = enemyDices.OrderDescending().ToArray();

        for(int i = 0; i < matchQtd; i++)
        {
            if(myDices[i] > enemyDices[i])
                enemy.ReceiveDMG(1);
            else if(enemyDices[i] >= myDices[i])
                this.ReceiveDMG(1);
        }     
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

public enum Side { Attack, Defense }