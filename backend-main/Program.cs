var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Cors
builder.Services.AddCors(o => o.AddPolicy("Cors", builder =>
{
	builder.AllowAnyOrigin();
	builder.AllowAnyMethod();
	builder.AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("Cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
