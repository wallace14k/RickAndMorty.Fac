using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RickAndMorty.Fac.Repositories;
using RickAndMorty.Fac.Repositories.Interfacies;
using RickAndMorty.Fac.Services;
using RickAndMorty.Fac.Services.Inteface;
using RickAndMorty.Fac.Utils;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new ArgumentNullException(builder.Configuration["Jwt:Key"]));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddSingleton<ICharacterRepository, CharacterRepository>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton(typeof(IGenericMongorepository<>), typeof(GenericMongoRepository<>));

builder.Services.AddHttpClient("RickAndMortyApi", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.WebApplicationsAddMaps(builder.Services,builder.Configuration);

app.Run();
