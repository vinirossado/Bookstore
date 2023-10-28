using Book.Infra.CrossCutting.Context;
using Book.Infra.CrossCutting.Validators;
using Book.Repository.Implements;
using Book.Repository.Interfaces;
using Book.Service.Implements;
using Book.Service.Interfaces;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<BookFilterDtoValidator>();
    
var app = builder.Build();
app.UseExceptionHandler(option => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

public partial class Program{ }
