using Financeiro.Company;

var builder = Company.GetBuilder();

builder
    .SetName("Empresa Juninho")
    .InBrazil()
    .SetInitialCapital(20_000_000);

builder
    .AddEmploye("Marquito Guanicera", 50_000)
    .AddEmploye("Jorge Ben", 20_000);

Company.New(builder);

Company.Current.Dismiss("Jorge Ben");   
Company.Current.Payment();