using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceService, ServiceManager>(); //required command to capture constructors
builder.Services.AddScoped<IServiceDal, EfServiceDal>(); //used to include entity part

builder.Services.AddScoped<ITeamService, TeamManager>();
builder.Services.AddScoped<ITeamDal, EfTeamDal>();

builder.Services.AddDbContext<AgricultureContext>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
