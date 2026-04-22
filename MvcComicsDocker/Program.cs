using Microsoft.EntityFrameworkCore;
using MvcComicsDocker.Data;
using MvcComicsDocker.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//string conn = builder.Configuration.GetConnectionString("ConnMySql");
string conn = builder.Configuration.GetConnectionString("ConnDocker");
builder.Services.AddTransient<RepositoryComics>();
builder.Services.AddDbContextPool<ComicsContext>(options => options.UseMySQL(conn));

builder.WebHost.UseUrls("http://0.0.0.0:80");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
