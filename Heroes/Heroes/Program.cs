using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Http;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Para rodar api*/
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=app.db"));
builder.Services.AddScoped<IHeroe, Repository>();
builder.Services.AddScoped<Service>();
/*Para rodar api*/


//Comunicação dos micro serviços HttClient
builder.Services.AddHttpClient<ILeague, LeagueClient>(Client =>
{
    Client.BaseAddress = new Uri("https://localhost:7139/");
});
builder.Services.AddScoped<Service>();


var app = builder.Build();

//Criar banco de dados
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}


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
