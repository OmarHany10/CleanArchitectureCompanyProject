
using CompanyProject.Core;
using CompanyProject.Infrustructure;
using CompanyProject.Infrustructure.Context;
using CompanyProject.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
