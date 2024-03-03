using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using T1PJ.DataLayer.Context;
using T1PJ.DataLayer.Entity;
using T1PJ.DataLayer.Entity.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<T1PJContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("T1PJConnect"), a => a.MigrationsAssembly("T1PJ.Application")));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 1;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<T1PJContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
