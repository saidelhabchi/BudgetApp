
using BudgetApp.Data;
using BudgetApp.Extensions;
using BudgetApp.Models;
using Microsoft.AspNetCore.Identity;

namespace BudgetApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services
                .AddIdentityApiEndpoints<AppUser>()
                .AddEntityFrameworkStores<DataContext>();

            builder.Services.AddServices(builder.Configuration);

            //Time provider service
            var timeProvider = TimeProvider.System;
            builder.Services.AddSingleton(_ => timeProvider);
            //Email sender service



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options => 
            options
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:4200")
                );

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapIdentityApi<AppUser>();

            app.MapControllers();

            app.Run();
        }
    }
}
