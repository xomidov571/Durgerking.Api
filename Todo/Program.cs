using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Todo.API.Data;
using Todo.Dtos;
using Todo.Services;
using Todo.Validatiors;

var builder = WebApplication.CreateBuilder(args);
var connestionString = builder.Configuration.GetConnectionString("localhost");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(connestionString));

builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddTransient<IValidator<CreateTodoDto>, CreateTodoValidation>();
builder.Services.AddTransient<IValidator<UpdateTodoDto>, UpdateTodoValidation>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
