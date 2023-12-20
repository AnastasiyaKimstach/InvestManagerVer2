

using InvestManagerVer2.Web.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InvestManager.Infrastructure.Data;
using InvestManagerVer2.Web.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("InvestManagetContextConnection") ?? throw new InvalidOperationException("Connection string 'InvestManagetContextConnection' not found.");

builder.Services.AddDbContext<InvestManagetContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<InvestManagerVer2WebUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<InvestManagetContext>();

InvestManager.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCoreServices();
builder.Services.AddRazorPages();

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");
app.MapRazorPages();

app.Run();
