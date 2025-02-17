using Microsoft.EntityFrameworkCore;
using ApiTest.Entity;
using ApiTest.Manager;
using ApiTest.ApiKey;
using ApiTest.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<TodoContext, TodoContext>();
builder.Services.AddScoped(typeof(TodoManager), typeof(TodoManager));
builder.Services.AddScoped<ApiKeyAuthFilter>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DBContext")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

// Possible to run API without Swagger or any graphic interface
//builder.Services.AddSwaggerGen();
//builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    // Possible to run API without Swagger or any graphic interface
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();