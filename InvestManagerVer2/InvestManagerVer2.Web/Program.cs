using InvestManager.Infrastructure.Data;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Repositories;
using InvestManagerVer2.Web.Servisces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//Failed to load configuration from file 'D:\source\repos\InvestManagerVer2\InvestManagerVer2\InvestManagerVer2.Web\appsettings.json'

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InvestManagerContext>(
    options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InvestManager;Trusted_Connection=True;MultipleActiveResultSets=true"));
builder.Services.AddScoped<IRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
