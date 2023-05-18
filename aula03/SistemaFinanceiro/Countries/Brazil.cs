namespace Financeiro.Factory;

using Process;

public class BrazilDismissProcess : IDismissalProcess
{
    public string Title => "Demissão de funcionário";

    public void Apply(DismissalArgs args)
    {
        System.Console.WriteLine(Title + " " + args.Employe.Name);
        args.Company.Money -= 3 * args.Employe.Wage + 500;
    }
}

public class BrazilWagePaymentProcess : IWagePaymentProcess
{
    public string Title => "Dia do pagamento";

    public void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= args.Employe.Wage * 1.45m;
    }
}

public class BrazilHiringProcess : IHiringProcess
{
    public string Title => "Contratação";

    public void Apply(HiringArgs args)
    {
        System.Console.WriteLine("Contratação do funcionario: " + args.Employe.Name);
        args.Company.Money += args.Employe.Wage * 0.5m;
    }
}

public class BrazilProcessFactory : IProcessFactory
{
    public IDismissalProcess CreateDismissalProcess()
        => new BrazilDismissProcess();

    public IWagePaymentProcess CreateWagePaymentProcess()
        => new BrazilWagePaymentProcess();

    public IHiringProcess CreateHiringProcess()
        => new BrazilHiringProcess();
}