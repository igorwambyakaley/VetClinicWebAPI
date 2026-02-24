using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using VetClinicAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace VetClinicAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "VetClinic API v1");
                    c.DocExpansion(DocExpansion.List);
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
