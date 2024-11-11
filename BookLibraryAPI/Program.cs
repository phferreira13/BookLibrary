using BookLibraryAPI.Queries;
using BookLibraryAPI.Repositories;
using BookLibraryAPI.Handlers;
using BookLibraryAPI.Commands;
using BookLibraryAPI.Validators;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR and FluentValidation services
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetBookByIdQuery>());

// Add BookRepository to the dependency injection container
builder.Services.AddSingleton<BookRepository>();

// Register DeleteBookCommandHandler with MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DeleteBookCommandHandler>());

// Registrar o validator
builder.Services.AddTransient<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
builder.Services.AddTransient<IValidator<UpdateBookCommand>, UpdateBookCommandValidator>();
// Registrar o comportamento de validação
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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
