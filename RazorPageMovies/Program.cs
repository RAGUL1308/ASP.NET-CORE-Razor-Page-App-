using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPageMovies.Data;
using RazorPageMovies.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//automtic update when refresh
var razorBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    razorBuilder.AddRazorRuntimeCompilation();
}

builder.Services.AddDbContext<RazorPageMoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPageMoviesContext") ?? throw new InvalidOperationException("Connection string 'RazorPageMoviesContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

app.MapRazorPages();

app.Run();
