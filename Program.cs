using Microsoft.AspNetCore.Identity;
using MyPets.Models;

using Microsoft.EntityFrameworkCore;
using MyPets.Data;
using System;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),

            sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,                 
            maxRetryDelay: TimeSpan.FromSeconds(10),  
            errorNumbersToAdd: null
        )


    ));

var app = builder.Build();





if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
