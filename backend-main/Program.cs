using backend_main.DataContext;
using backend_main.Interfaces;
using backend_main.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ISqlContext, SqlContext>();

// Cors
builder.Services.AddCors(o => o.AddPolicy("Cors", builder =>
{
	builder.AllowAnyOrigin();
	builder.AllowAnyMethod();
	builder.AllowAnyHeader();
}));

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SqlContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("Cors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
