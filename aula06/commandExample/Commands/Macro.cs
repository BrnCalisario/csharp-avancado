using System.Linq;
using System.Collections.Generic;

namespace Example.Commands;

public class Macro : ICommand
{
    private List<ICommand> commands = new List<ICommand>();
    private List<string[]> parameters = new List<string[]>();

    public string Name { get; set; }

    public Macro(string name) 
        => this.Name = name;
        
    public void Add(ICommand command, string[] parameters)
    {
        this.commands.Add(command);
        this.parameters.Add(parameters);
    }
    
    public string Apply(string text, string[] parameters)
    {
        for(int i = 0; i < commands.Count; i++)
            text = this.commands[i].Apply(text, this.parameters[i]);
        
        System.Console.WriteLine(text);
        return text;
    }

}