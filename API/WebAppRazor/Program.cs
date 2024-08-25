using ApiTest.Entity;
using ApiTest.Manager;
using Microsoft.EntityFrameworkCore;
using WebAppRazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddScoped<TodoContext, TodoContext>();
builder.Services.AddScoped(typeof(TodoManager), typeof(TodoManager));
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DBContext")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();