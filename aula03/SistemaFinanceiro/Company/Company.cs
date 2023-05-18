/* 
    Implementando um Singleton para a classe Company
    Composição de um singleton: 
    Construtor Privado
    Atributo privado estático de si mesmo
    Atributo publico estático que referencia o atributo privado
    Funções que "reiniciam" o objeto
*/

using System.Linq;
using System.Collections.Generic;

namespace Financeiro.Company;

using Process;
using Factory;

public class Employe
{
    public string Name { get; set; }
    public decimal Wage { get; set; }
}

public class Company
{
    private Company() { }

    private static Company crr = null;
    public static Company Current => crr;

    public string Name { get; set; }
    public decimal Money { get; set; }

    private List<Employe> employees = new List<Employe>();
    public IEnumerable<Employe> Employees => employees;

    private IDismissalProcess dismissalProcess = null;
    private IWagePaymentProcess wagePaymentProcess = null;
    private IHiringProcess hiringProcess = null;
    
    
    public void Contract(Employe e)
    {
        HiringArgs args = new HiringArgs();
        args.Company = this;
        args.Employe = e;

        hiringProcess.Apply(args);
    
        employees.Add(e);
    }

    public void Dismiss(string name)
    {
        var employe = employees.FirstOrDefault(x => x.Name == name);

        if(employe is null)
            return;

        DismissalArgs args = new DismissalArgs();

        args.Employe = employe;
        args.Company = this;

        dismissalProcess.Apply(args);

        employees.Remove(employe);
    }

    public void Payment()
    {
        foreach(var e in employees)
        {
            WagePaymentArgs args = new WagePaymentArgs();
            args.Employe = e;
            args.Company = this;
            wagePaymentProcess.Apply(args);
        }
    }


    /*
        Construtor de Classe:
            Irá conter:
                uma instância privada da classe desejada
                funções que retornam o próprio construtor para uma sintáxe mais compacta e legível
                caso haja atributos de classes abstratas, colocar opção de setar uma factory para entregar métodos desejados
    */  

    public class CompanyBuilder
    {
        private Company company = new Company();

        public Company Build()
            => this.company;

        public CompanyBuilder SetName(string name)
        {
            company.Name = name;
            return this;
        }

        public CompanyBuilder SetInitialCapital(decimal money)
        {
            company.Money = money;
            return this;
        }

        public CompanyBuilder AddEmploye(string name, decimal wage)
        {
            Employe e = new Employe() { Name = name, Wage = wage }; 
            company.Contract(e);
            return this;
        }

        public CompanyBuilder SetFactory(IProcessFactory factory)
        {
            company.dismissalProcess = factory.CreateDismissalProcess();
            company.wagePaymentProcess = factory.CreateWagePaymentProcess();
            company.hiringProcess = factory.CreateHiringProcess();

            return this;
        }
    }

    public static CompanyBuilder GetBuilder()
        => new CompanyBuilder();

    public static void New(CompanyBuilder builder)
        => crr = builder.Build();
    
}

public static class CompanyBuilderExtension
{
    public static Company.CompanyBuilder InBrazil(this Company.CompanyBuilder builder)
    {
        builder.SetFactory(new BrazilProcessFactory());
        return builder;
    }

    public static Company.CompanyBuilder InArgentina(this Company.CompanyBuilder builder)
    {
        builder.SetFactory(new ArgentinaProcessFactory());
        return builder;
    }

    public static Company.CompanyBuilder InUnitedStates(this Company.CompanyBuilder builder)
    {
        builder.SetFactory(new UnitedStatesProcessFactory());
        return builder;
    }
}