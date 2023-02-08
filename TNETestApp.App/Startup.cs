using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Serilog;
using TNETestApp.Infrastructure;
using TNETestApp.Services;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace TNETestApp.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext().CreateLogger();

            Log.Information("Starting web application");

            services.AddDbContext<DataContext>(options =>
            {
                options
                    .UseNpgsql(Configuration.GetConnectionString("TNETestAppDb"))
                    .UseSnakeCaseNamingConvention();
                if (Configuration.GetValue<bool>("LogSqlCommands"))
                {
                    options.LogTo(Console.WriteLine);
                }
            },

                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Singleton);

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "TNETestApp", Version = "v1" });
            });

            services.AddTNETestAppServices();
            services.AddHostedService<PrepareDbHostedService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "TNETestApp.App v1"));
            }

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(e =>
            {
                e.MapControllers();
            });
        }
    }
}
