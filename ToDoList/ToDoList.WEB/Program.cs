using Microsoft.EntityFrameworkCore;
using ToDoList.BLL.Interfaces;
using ToDoList.BLL.Services;
using ToDoList.DAL;
using ToDoList.DAL.Interfaces;
using ToDoList.DAL.Repositories;
using ToDoList.WEB.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)))
);
builder.Services.AddControllersWithViews();
builder.Services.AddLogging();

builder.Services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();
builder.Services.AddScoped<IToDoListItemService, ToDoListItemService>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ToDoList/Error");
    app.UseHsts();
}

app.ConfigureExceptionHandler(app.Logger);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapGet("/myroot", (ApplicationDbContext db) => db.ToDoListItems.ToList());
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDoList}/{action=Index}/{id?}");

app.Run();
