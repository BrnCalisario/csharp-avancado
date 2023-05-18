namespace Financeiro.Process;

public interface IProcess
{
    string Title { get; }
}

public interface IDismissalProcess : IProcess
{
    void Apply(DismissalArgs args);
}

public interface IWagePaymentProcess : IProcess
{
    void Apply(WagePaymentArgs args);
}

public interface IHiringProcess : IProcess
{
    void Apply(HiringArgs args);
}