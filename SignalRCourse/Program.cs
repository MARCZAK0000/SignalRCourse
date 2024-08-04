using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SignalRCourse.Authentication;
using SignalRCourse.Database;
using SignalRCourse.Hubs;
using SignalRCourse.Middleware;
using SignalRCourse.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(pr =>
{
    pr.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"));
});

builder.Services.AddScoped<ErrorMiddleware>();

builder.Services.AddSignalR();
builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserContext,  UserContext>();
builder.Services.AddScoped<IJobToDoRepository, JobToDoRepository>();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<ErrorMiddleware>();   
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<UserHub>("/hub/userhub");
app.MapHub<NotificationHub>("/hub/notification");
app.MapHub<ChatBotHub>("/hub/chatbot");
app.Run();
