using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services avant de construire l'application
builder.Services.AddControllers();

// Ajouter la configuration de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ajouter la configuration CORS (si nécessaire)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Ajouter la configuration de la base de données
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DATABASE");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Une fois tous les services configurés, construire l'application
var app = builder.Build();

// Configurer la pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Appliquer la politique CORS
app.UseCors("AllowAll");

// Mapper les contrôleurs
app.MapControllers();

// Route de base pour tester l'API
app.MapGet("/", () => "API en cours d'exécution");

app.Run();
