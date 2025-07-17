using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using PDFProcessor.Models;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=localhost;Database=PruebaPDF;Trusted_Connection=True;TrustServerCertificate=True"));

        services.AddLogging(config =>
        {
            config.AddConsole();
            config.AddEventLog();
        });
    })
    .Build();

await host.RunAsync();
