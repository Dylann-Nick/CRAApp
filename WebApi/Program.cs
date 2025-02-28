using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Récupération de la chaîne de connexion
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Ajout du DbContext avec SQL Server
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Ajout des services nécessaires
        builder.Services.AddControllers();

        // Ajout des services OpenAPI / Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Compte rendu d'activité Aoi",
                Version = "v1",
                Description = "API pour la gestion des Comptes Rendus d'Activité en formation/entreprise",
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
                options.RoutePrefix = ""; // Swagger sera accessible à la racine de l'API
            });
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
