using Context;
using Microsoft.EntityFrameworkCore;
using Repositorios;

namespace API_PERSONAS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ContextPersonas>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:ConexionDatos"]);
            });
            builder.Services.AddTransient<IRepositorioPersonas, RepositorioPersonas>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAll");
            app.UseCors(policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Permite solicitudes desde esta URL
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}