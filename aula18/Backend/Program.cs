using Backend.Model;
using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MainPolicy",
        policy => 
        {
            policy
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;
const string url = "https://viacep.com.br/ws/80320330/json/";

// Injeção de dependencia
builder.Services.AddScoped<RepoExemploContext>();

if(env.IsDevelopment())
    builder.Services.AddTransient<IRepository<Mensagem>, MessageRepository>();
else if(env.IsProduction())
    builder.Services.AddTransient<IRepository<Mensagem>, MessageRepository>();


builder.Services.AddSingleton<ICepService>(p => new CepService(url));

builder.Services.AddTransient<CpfService>();


var app = builder.Build();

app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
