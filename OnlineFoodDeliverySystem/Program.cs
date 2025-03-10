using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FoodDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
