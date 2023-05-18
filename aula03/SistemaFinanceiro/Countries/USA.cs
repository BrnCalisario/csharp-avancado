namespace Financeiro.Factory;

using Process;


public class UnitedStatesDismissProcess : IDismissalProcess
{
    public string Title => "Dismiss an employe";

    public void Apply(DismissalArgs args)
    {
        args.Company.Money -= 3 * args.Employe.Wage + 1000;
    }
}

public class UnitedStatesPaymentProcess : IWagePaymentProcess
{
    public string Title => "Pay Day";

    public void Apply(WagePaymentArgs args)
    {
        args.Company.Money -= args.Employe.Wage * 3;
    }
}

public class UnitedStatesProcessFactory : IProcessFactory
{
    public IDismissalProcess CreateDismissalProcess()
        => new UnitedStatesDismissProcess();

    public IWagePaymentProcess CreateWagePaymentProcess()
        => new UnitedStatesPaymentProcess();

    public IHiringProcess CreateHiringProcess()
        => new BrazilHiringProcess();
}
