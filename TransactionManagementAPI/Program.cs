using TransactionManagementAPI.Middlewares;
using TransactionManagementAPI.Services;
using TransactionManagementAPI.Services.Concretes;
using TransactionManagementAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

// Adding the FakeTransactionService to the DI container.
// Whenever an ITransactionService is required, an instance of FakeTransactionService will be provided.
builder.Services.AddScoped<ITransactionService, FakeTransactionService>();
// Adding the FakeUserService to the DI container.
builder.Services.AddScoped<IUserService, FakeUserService>();

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

// Add the RequestLoggingMiddleware to the pipeline.
// This should be one of the first middlewares to log all incoming HTTP requests.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();