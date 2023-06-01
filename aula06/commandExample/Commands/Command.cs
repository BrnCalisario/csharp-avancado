using System.Linq;

namespace Example.Commands;

public interface ICommand
{
    string Apply(string text, string[] parameters);
}

public class AddCommand : ICommand
{
    public string Apply(string text, string[] parameters)
    {
        string addedText = parameters.Aggregate("", (a, s) => a + s + " ");
        addedText = addedText.Substring(0, addedText.Length - 1);
        return text + addedText;
    }
}

public class ClearCommand : ICommand
{
    public string Apply(string text, string[] parameters)
        => "";
}

public class CapitalizeCommand : ICommand
{
    public string Apply(string text, string[] parameters)
        => text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1);

}

public class ReverseCommand : ICommand
{
    public string Apply(string text, string[] parameters)
        => string.Concat(text.Reverse());
}
