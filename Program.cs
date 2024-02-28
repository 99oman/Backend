using Backend.Context;
using Backend.IRepository;
using Backend.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<DbContext>();
            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("corspolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}