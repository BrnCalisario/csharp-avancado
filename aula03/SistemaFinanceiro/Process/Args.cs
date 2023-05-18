namespace Financeiro.Process;

using Company;

public class ProcessArgs
{
    private ProcessArgs empty = new ProcessArgs();
    public ProcessArgs Empty => empty;
}

public class DismissalArgs
{
    public Company Company { get; set; }
    public Employe Employe { get; set; }
}

public class WagePaymentArgs
{
    public Company Company { get; set;}
    public Employe Employe { get; set;}
}

public class HiringArgs
{
    public Company Company { get; set; }
    public Employe Employe { get; set; }
}