using Microsoft.EntityFrameworkCore;
using Vendas.Api.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<VendasDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VendasConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.


  app.UseSwagger();
  app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
