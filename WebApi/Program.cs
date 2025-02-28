using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // R�cup�ration de la cha�ne de connexion
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Ajout du DbContext avec SQL Server
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Ajout des services n�cessaires
        builder.Services.AddControllers();

        // Ajout des services OpenAPI / Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Compte rendu d'activit� Aoi",
                Version = "v1",
                Description = "API pour la gestion des Comptes Rendus d'Activit� en formation/entreprise",
                Contact = new OpenApiContact
                {
                    Name = "Support",
                    Email = "support@cra.com",
                    Url = new Uri("https://cra.com")
                }
            });
        });

        var app = builder.Build();

        // Ajout du middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CRA API v1");
                options.RoutePrefix = ""; // Swagger sera accessible � la racine de l'API
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
