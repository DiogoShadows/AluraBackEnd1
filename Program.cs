using AluraBackEnd1.Data;
using AluraBackEnd1.Services;
using AluraBackEnd1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AluraBackEnd1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            string connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["FinanceiroConnection"];
            builder.Services.AddDbContext<FinanceiroContext>(opts => opts.UseSqlServer(connection));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Injeção dos services
            builder.Services.AddScoped<IReceitaService, ReceitaService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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