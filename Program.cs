using Horas.Controllers;
using Horas.Persistence;
using Horas.Services;
using Microsoft.EntityFrameworkCore;

namespace Horas
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            //services
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            //db
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddDbContext<HourContext>(options =>
                options.UseNpgsql(connectionString));
            
            //dependency inyection
            builder.Services.AddScoped<IHourRepository, HourRepository>();
            builder.Services.AddScoped<HourService>();


            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();


            Console.WriteLine("Ya esta corriendo mi api :)))");
            app.Run("http://localhost:4050/");
        }
    }
}