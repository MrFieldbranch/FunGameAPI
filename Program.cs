using FunGameAPI.Data;
using FunGameAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<LoginService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins(
            "https://hangman-game-la5u.onrender.com",
            "http://localhost:5173"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services
  .AddAuthentication()
  .AddJwtBearer(options =>
  {
      var signingSecret = builder.Configuration["JWT:SigningSecret"]
      ?? throw new InvalidOperationException("JWT SigningSecret is not configured.");

      var signingKey = Convert.FromBase64String(signingSecret);

      options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateLifetime = false,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(signingKey)
      };
  });

var app = builder.Build();

app.UseCors("AllowSpecificOrigins");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

