using System;
using System.Collections.Generic;
using static System.Console;

public interface IEmployee
{
    void ReceiveMessage(string message);
}

public class Boss : IEmployee
{
    List<IEmployee> employees = new List<IEmployee>();
    IEnumerable<IEmployee> Employees => employees; 

    public void Hire(IEmployee employee)
        => employees.Add(employee);

    public void ReceiveMessage(string message)
    {
        if(message.ToLower().Contains("confidencial"))
            return;
        
        foreach(var e in employees)
            e.ReceiveMessage(message);
    }
}

public class Secretary : IEmployee
{
    public IEmployee Employee { get; set; }
    private string[] prefixList = new string[] { "Confidencial", "Importante", "Memorando" };
    public void ReceiveMessage(string message)
    {
        string newMessage = message;
        foreach(var p in prefixList)
            if(message.ToLower().Contains(p.ToLower()))
                newMessage = p + ": " + message;        

        Employee.ReceiveMessage(newMessage);        
    }
}

public class Trainee : IEmployee
{
    public void ReceiveMessage(string message)
    {
        if(message.ToLower().Contains("confidencial"))
            return;

        WriteLine(message);
    }
}

public class Programmer : IEmployee
{
    public void ReceiveMessage(string message)
    {
        WriteLine("Mensagem Recebida");
    }
}