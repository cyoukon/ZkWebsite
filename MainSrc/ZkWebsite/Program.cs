using PluginCore.AspNetCore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. Ìí¼Ó PluginCore
builder.Services.AddPluginCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

// 2. Ê¹ÓÃ PluginCore
app.UsePluginCore();

app.MapGet("/health", () =>
{
    return Results.Ok();
})
.WithName("CheckHealth");

app.MapControllers();

app.Run();