using System.Text;

namespace Example.Commands;

public abstract class ParameterCommand : ICommand
{
    protected abstract int numParams { get; set; }

    public string Apply(string text, string[] parameters)
    {
        if(parameters.Length < numParams)
            return defaultHandler(text);

        return sucessHandler(text, parameters);        
    }

    protected abstract string defaultHandler(string text);
    protected abstract string sucessHandler(string text, string[] parameters);
}

public class SubstringCommand : ParameterCommand
{
    protected override int numParams { get; set; } = 2;

    protected override string defaultHandler(string text)
        => text;

    protected override string sucessHandler(string text, string[] parameters)
    {
        int start = int.Parse(parameters[0]);
        int size = int.Parse(parameters[1]);

        if(size > text.Length)
            return string.Empty;

        if(start + size > text.Length)
            return text.Substring(size);

        return text.Substring(start, size);        
    }
}

public class SubtractCommand : ParameterCommand
{
    protected override int numParams { get; set; } = 1;

    protected override string defaultHandler(string text)   
        => text;

    protected override string sucessHandler(string text, string[] parameters)
    {
        int qtd = int.Parse(parameters[0]);

        if(qtd > text.Length)
            return string.Empty;

        return text.Substring(0, text.Length - qtd);        
    }
}