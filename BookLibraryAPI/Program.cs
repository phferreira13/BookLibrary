using BookLibraryAPI.Queries;
using BookLibraryAPI.Repositories;
using BookLibraryAPI.Handlers;

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
