using Microsoft.EntityFrameworkCore;
using ToDoList.DAL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ApplicationDbContext)))
);
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/ToDoList/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapGet("/myroot", (ApplicationDbContext db) => db.ToDoListItems.ToList());
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDoList}/{action=Index}/{id?}");

app.Run();
