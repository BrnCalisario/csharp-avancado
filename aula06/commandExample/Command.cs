using System.Linq;
using System.Text;

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

public class SubtractCommand : ICommand
{
    public string Apply(string text, string[] parameters)
    {
        int qtd = int.Parse(parameters[0]);

        if (qtd > text.Length)
            return string.Empty;

        return text.Substring(0, text.Length - qtd);
    }
}

public abstract class RangeCommand : ICommand
{
    protected abstract string handleText(string text);
    public string Apply(string text, string[] parameters)
    {
        if (parameters.Length == 0)
            return handleText(text);

        int start = int.Parse(parameters[0]);
        int size = int.Parse(parameters[1]);

        if (size > text.Length || size + start > text.Length)
            return handleText(text);

        bool flag = false;

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            flag = i >= start && i < start + size;

            if (flag)
                sb.Append(handleText(text.Substring(i, 1)));
            else
                sb.Append(text[i]);
        }

        return sb.ToString();
    }
}

public class UpperCaseCommand : RangeCommand
{
    protected override string handleText(string text)
        => text.ToUpper();
}

public class LowerCaseCommand : RangeCommand
{
    protected override string handleText(string text)
        => text.ToLower();
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

