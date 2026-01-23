using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MilkyWayCitizen.Back.API.Services;
using MilkyWayCitizen.Back.BLL.Services;
using MilkyWayCitizen.Back.DAL.Contexts;
using MilkyWayCitizen.Back.DAL.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
    {           //  Ce sont les options s curitaires de base. La doc existe pour d'autres options sp cifiques au besoin.
        Name="Authorization",
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description="JWT Authorization: Entrez : 'Bearer [token]'"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {       //  Permet de rajouter un cadenas sur les routes
        {
            new OpenApiSecurityScheme
            {
                Reference=new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[] { }
        }
    });
});

#region DbContext
// Add DB Context
builder.Services.AddDbContext<MilkyWayContext>(b =>
    b.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);// */
#endregion

#region Repositories
builder.Services.AddScoped<NewsRepository>();
builder.Services.AddScoped<UserRepository>();
#endregion

#region Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<NewsService>();
builder.Services.AddScoped<UserService>();
#endregion

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters=new TokenValidationParameters
    {
        ValidateIssuerSigningKey=true,
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateLifetime=true,

        //  Optionnel mais un peu utile
        ValidateAudience=true,
        ValidAudience=builder.Configuration["Jwt:Audience"],

        ValidateIssuer=true,
        ValidIssuer=builder.Configuration["Jwt:Issuer"],
    };
});

builder.Services.AddCors(service =>
{
    service.AddPolicy("FFA",policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });

    // TODO : Add more CORS policies for production
});

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("FFA");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
