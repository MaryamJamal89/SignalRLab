using Microsoft.EntityFrameworkCore;
using SignalrD1.Models;
using SignalrD1.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<signalrchatContext>(n => n.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
builder.Services.AddSignalR();
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
//app.MapHub<ChatHub>("/chathub");
app.MapHub<UserHub>("/userhub");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=user}/{action=Index}/{id?}");

app.Run();
