// Program.cs
using AICreatedProjectBackend.Data;
using AICreatedProjectBackend.Helpers;
using AICreatedProjectBackend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);
builder.Services.AddSingleton(sp =>
      sp.GetRequiredService<IOptions<JwtSettings>>().Value);

var jwtSettingsInstance = jwtSettings.Get<JwtSettings>()!;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettingsInstance.Issuer,
        ValidAudience = jwtSettingsInstance.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsInstance.Secret))
    };
});

// Register services
builder.Services.AddScoped<IAuthService, AuthService>();

// Add CORS for React Native
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactNative", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Backend/Program.cs - Update CORS for production
if (app.Environment.IsProduction())
{
    var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL") 
                      ?? "https://myapp-frontend-web.onrender.com";
    
    app.UseCors(builder => builder
        .WithOrigins(
            frontendUrl,
            "https://myapp-backend.onrender.com"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
}
else
{
    app.UseCors("ReactNative");
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Initialize database
//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    context.Database.Migrate();
//}

app.Run();