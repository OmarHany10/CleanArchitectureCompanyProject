
using CompanyProject.Core;
using CompanyProject.Core.MiddleWare;
using CompanyProject.Infrustructure;
using CompanyProject.Infrustructure.Context;
using CompanyProject.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace CompanyProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            builder.Services.AddInfrustructureDependencies();
            builder.Services.AddServiceDependencies();
            builder.Services.AddCoreDependencies();

            #region Localization

            builder.Services.AddLocalization(opt => { opt.ResourcesPath = ""; });
            builder.Services.Configure<RequestLocalizationOptions>(opt =>
            {
                List<CultureInfo> cultureInfos = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("ar-EG")
                };

                opt.DefaultRequestCulture = new RequestCulture("en-US");
                opt.SupportedCultures = cultureInfos;
                opt.SupportedUICultures = cultureInfos;
            });

            #endregion
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
