using FactoryPattern.Factories;
using FactoryPattern.Interfaces;
using FactoryPattern.Models;
using FactoryPattern.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IErrorsDisplayerFactory, ErrorsDisplayerFactory>();
builder.Services.AddKeyedScoped<IErrorsDisplayer, BasicErrorsDisplayer>(nameof(BasicErrorsDisplayer));
builder.Services.AddKeyedScoped<IErrorsDisplayer, PrettyErrorsDisplayer>(nameof(PrettyErrorsDisplayer));
builder.Services.AddKeyedScoped<IErrorsDisplayer, AdvancedErrorsDisplayer>(nameof(AdvancedErrorsDisplayer));

using IHost host = builder.Build();

Run(host.Services);

await host.RunAsync();

static void Run(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var factory = provider.GetRequiredService<IErrorsDisplayerFactory>();
    var errors = new List<Error> { new("ABC1", "This is a error text."), new("ABC2", "Put something to show."), new("ABC3", "More error text.") };

    Console.WriteLine("Basic:");
    factory.Create(FactoryPattern.ErrorDisplayerType.Basic).Write(errors);
    Console.WriteLine();

    Console.WriteLine("Pretty:");
    factory.Create(FactoryPattern.ErrorDisplayerType.Pretty).Write(errors);
    Console.WriteLine();

    Console.WriteLine("Advanced:");
    factory.Create(FactoryPattern.ErrorDisplayerType.Advanced).Write(errors);
    Console.WriteLine();
}