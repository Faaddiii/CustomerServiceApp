using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerServiceApp.Data;
using CustomerServiceApp.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<CustomerServiceAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerServiceAppContext") ?? throw new InvalidOperationException("Connection string 'CustomerServiceAppContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //app.UseHttpsRedirection();
    app.UseHsts();
}


app.UseStaticFiles();

app.UseRouting();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(_ => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
