using Microsoft.EntityFrameworkCore;
using TaskManagment.Infrastructure.DBContext;
using TaskManagment.Infrastructure.Repository;
using TaskManagment.Domain.Interfaces;
using TaskManagment.Application.Servises;
using Microsoft.Extensions.Configuration;
using TaskManagment.Infrastructure.DBContext;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddScoped<IRepository, TaskRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<TaskServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
