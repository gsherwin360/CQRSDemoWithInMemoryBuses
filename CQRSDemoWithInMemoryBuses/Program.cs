var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the in-memory command bus and command handlers
builder.Services
    .AddInMemoryCommandBus()
    .AddCommandHandlerInAssemblyOf<Program>();

// Register the query bus and query handlers
builder.Services
    .AddQueryBus()
    .AddQueryHandlerInAssemblyOf<Program>();

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