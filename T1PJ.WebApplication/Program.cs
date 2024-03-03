using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using T1PJ.DataLayer;
using T1PJ.DataLayer.Context;
using T1PJ.DataLayer.Entity.Identity;
using T1PJ.Repository.Extensions;
using T1PJ.Repository.Helpers.Students;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services
    .AddDbContext<T1PJContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("T1PJConnect") ?? throw new InvalidOperationException("Connection string 'T1PJContext' not found."), b => b.MigrationsAssembly("T1PJ.WebApplication")));
builder.Services.AddDbContext<T1PJContext>(ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 1;
    options.Password.RequireDigit = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddSignInManager<SignInManager<User>>()
    .AddEntityFrameworkStores<T1PJContext>();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/Accounts/Login");
builder.Services.AddAutoMapper(typeof(MappingProfile));

// register services
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
