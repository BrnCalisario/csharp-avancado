namespace Financeiro.Factory;

using Process;

public interface IProcessFactory
{
    IWagePaymentProcess CreateWagePaymentProcess();
    IDismissalProcess CreateDismissalProcess();
    IHiringProcess CreateHiringProcess();
}