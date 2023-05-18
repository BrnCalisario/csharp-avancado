namespace Financeiro.Factory;

using Process;

public class ArgentinaDismissProcess : IDismissalProcess
{
    public string Title => "Despacho de manito";

    public void Apply(DismissalArgs args)
    {
        args.Company.Money -= 5 * args.Employe.Wage + 250;
    }
}


public class ArgentinaWagePaymentProcess : IWagePaymentProcess
{
    public string Title => "Dia del Cascaleo";

    public void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= args.Employe.Wage * 2.25m;
    }
}


public class ArgentinaProcessFactory : IProcessFactory
{
    public IDismissalProcess CreateDismissalProcess()
        => new ArgentinaDismissProcess();

    public IWagePaymentProcess CreateWagePaymentProcess()
        => new ArgentinaWagePaymentProcess();

    public IHiringProcess CreateHiringProcess()
        => new BrazilHiringProcess();
}
