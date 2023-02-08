
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Net;
using TNETestApp.App;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally 
        {
            Log.CloseAndFlush();
        }
        
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext().CreateLogger();

            webBuilder.ConfigureLogging(options =>
            {
                options.ClearProviders();
                options.AddSerilog();
            });

            webBuilder.UseSerilog();

            webBuilder.UseKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 8050);
            });
            webBuilder.UseStartup<Startup>();
            
        });
}



//using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
//using Serilog;
//using TNETestApp.Infrastructure;
//using TNETestApp.Services;

//try
//{
//    Log.Information("Starting web application");

//    var builder = WebApplication.CreateBuilder(args);

//    Log.Logger = new LoggerConfiguration()
//        .ReadFrom.Configuration(builder.Configuration)
//        .Enrich.FromLogContext().CreateLogger();

//    builder.Logging.ClearProviders();
//    builder.Logging.AddSerilog();

//    // Add services to the container.

//    builder.Services.AddDbContext<DataContext>(options =>
//    {
//        options
//            .UseNpgsql(builder.Configuration.GetConnectionString("TNETestAppDb"))
//            .UseSnakeCaseNamingConvention();
//        if (builder.Configuration.GetValue<bool>("LogSqlCommands"))
//        {
//            options.LogTo(Console.WriteLine);
//        }
//    },

//        contextLifetime: ServiceLifetime.Transient,
//        optionsLifetime: ServiceLifetime.Singleton
//    );

//    builder.Services.AddControllers().AddNewtonsoftJson(options =>
//    {
//        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//    });
//    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//    builder.Services.AddEndpointsApiExplorer();
//    builder.Services.AddSwaggerGen();

//    builder.Services.AddTNETestAppServices();
//    builder.Services.AddHostedService<PrepareDbHostedService>();

//    builder.Host.UseSerilog();

//    var app = builder.Build();

//    app.UseSerilogRequestLogging();

//    // Configure the HTTP request pipeline.
//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI();
//    }

//    app.UseHttpsRedirection();

//    app.UseAuthorization();

//    app.MapControllers();

//    app.Run();

//}
//catch (Exception ex)
//{
//    Log.Fatal(ex, "Application terminated unexpectedly");
//}
//finally
//{
//    Log.CloseAndFlush();
//}
