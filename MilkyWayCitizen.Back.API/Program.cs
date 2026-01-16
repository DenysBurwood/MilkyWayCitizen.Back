using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddSwaggerGen();

#region DbContext
// Add DB Context
builder.Services.AddDbContext<MilkyWayContext>(b =>
    b.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);// */
#endregion

#region Repositories
builder.Services.AddScoped<UserRepository>();
#endregion

#region Services
builder.Services.AddScoped<AuthService>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
