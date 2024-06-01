using Course.Business.Interfaces;
using Course.Business.Services;
using Course.Infrastructure.Contexts;
using CourseAPI.GraphQL.Mutations;
using CourseAPI.GraphQL.Queries;
using CourseAPI.GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets<Program>();

string dbString = builder.Configuration["DbString"]!;
string dbName = builder.Configuration["DbName"]!;

string JwtIssuer = builder.Configuration["JwtSettings:Issuer"]!;
string JwtAudience = builder.Configuration["JwtSettings:Audience"]!;
string JwtKey = builder.Configuration["JwtSettings:Key"]!;

builder.Services.AddPooledDbContextFactory<CourseDbContext>(x =>
{
    x.UseCosmos(dbString, dbName)
    .UseLazyLoadingProxies();
});

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<CourseMutation>()
    .AddType<CourseType>()
    .AddAuthorization();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = JwtIssuer,
        ValidAudience = JwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtKey)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<CourseDbContext>>();
    using var context = dbContextFactory.CreateDbContext();
    context.Database.EnsureCreated();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
