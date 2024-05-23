using User.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using User.Business.Services;
using User.Infrastructure.Entities;
using User.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserDb")));

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddIdentityCore<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<UserDbContext>().AddApiEndpoints();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AddressService>();

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapIdentityApi<UserEntity>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
