using System.Text;

namespace Example.Commands;

public abstract class RangeCommand : ParameterCommand
{
    protected override int numParams { get; set; } = 2;

    protected override string sucessHandler(string text, string[] parameters)
    {
        int start = int.Parse(parameters[0]);
        int size = int.Parse(parameters[1]);

        if(size > text.Length || size + start > text.Length)
            return defaultHandler(text);
        
        bool flag = false;

        StringBuilder sb = new StringBuilder();

        for(int i = 0; i < text.Length; i++)
        {
            flag = i >= start && i < start + size;

            if(flag)
                sb.Append(defaultHandler(text.Substring(i, 1)));
            else
                sb.Append(text[i]);
        }

        return sb.ToString();
    }
}    

public class UpperCaseCommand : RangeCommand
{
    protected override string defaultHandler(string text)
        => text.ToUpper();
}

public class LowerCaseCommand : RangeCommand
{
    protected override string defaultHandler(string text)
        => text.ToLower();
}