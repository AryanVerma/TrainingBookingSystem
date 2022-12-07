using Autofac;
using Autofac.Extensions.DependencyInjection;
using Training.Infrastructure.DataContext;
using TrainingAPI.Helpers;
using TrainingAPI.StartupServices;
using TrainingAPI.StartupSpecifications;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
ConfigurationHelper.Init(configuration);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

// Add services to the container.
builder.Services.AddRepository();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
