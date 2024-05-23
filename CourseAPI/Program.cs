using Course.Business.Interfaces;
using Course.Business.Services;
using Course.Infrastructure.Contexts;
using CourseAPI.GraphQL.Mutations;
using CourseAPI.GraphQL.Queries;
using CourseAPI.GraphQL.Types;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddPooledDbContextFactory<CourseDbContext>(x =>
{
    x.UseCosmos(dbString, dbName)
    .UseLazyLoadingProxies();
});

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<CourseMutation>()
    .AddType<CourseType>();

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

app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
