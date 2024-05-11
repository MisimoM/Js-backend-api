using Admin.Business.Services;
using Admin.Infrastructure.Contexts;
using Admin.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AdminDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("AdminDb")));

builder.Services.AddIdentityCore<AdminEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;

})  .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AdminDbContext>();

builder.Services.AddScoped<AdminService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Administrator", "Manager", "Staff" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AdminEntity>>();

    string email = "admin@admin.com";
    string password = "Admin123!";

    if(await userManager.FindByEmailAsync(email) is null)
    {
        var user = new AdminEntity
        {   
            FirstName = "Admin",
            LastName = "Admin",
            Email = email,
            UserName = email
        };

        await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Administrator");
    }
}

app.Run();
