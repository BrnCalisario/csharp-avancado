using System;
using System.Linq;
using System.Collections.Generic;

namespace Example.Invoke;

using Commands;

public class Invoker
{
    public string Text { get; set; }

    public Invoker()
    {
        commandDict.Add("add", new AddCommand());
        commandDict.Add("rev", new ReverseCommand());
        commandDict.Add("rem", new SubtractCommand());
        commandDict.Add("sub", new SubstringCommand());
        commandDict.Add("clr", new ClearCommand());
        commandDict.Add("upp", new UpperCaseCommand());
        commandDict.Add("low", new LowerCaseCommand());
        commandDict.Add("cap", new CapitalizeCommand());
    }

    public IEnumerable<string> Commands => commandDict.Keys.Append("macro");
    private Dictionary<string, ICommand> commandDict = new Dictionary<string, ICommand>();
    
    private Macro macro = null;
    private bool macroMode = false;

    public void UseCommand(string comm)
    {
        comm = comm.Trim();
        var parts = comm.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return;

        if (parts[0] == "help")
        {
            Console.WriteLine("Comandos Disponíveis");
            foreach (var com in Commands)
                Console.WriteLine(com);

            Console.ReadKey(true);
            return;
        }

        if(parts[0] == "macro")
        {
            macroMode = !macroMode;

            if(macroMode)
                macro = new Macro(parts[1]);
            else
                commandDict.Add(macro.Name, macro);

            return;
        }

        if(macroMode)
        {
            macro.Add(commandDict[parts[0]], parts.Skip(1).ToArray());
            return;
        }


        if (!this.commandDict.ContainsKey(parts[0]))
        {
            Console.WriteLine("Comando não existe!");
            Console.ReadKey(true);
            return;
        }

        this.Text = commandDict[parts[0]].Apply(this.Text, parts.Skip(1).ToArray());
    }

}