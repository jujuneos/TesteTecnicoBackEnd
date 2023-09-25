using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TesteTecnico.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

string connection = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connection));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions
            .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddHttpsRedirection(options => 
{
    options.HttpsPort = 44342;
});

builder.Services.AddHttpClient("TesteTecnico", a =>
{
    a.BaseAddress = new Uri(builder.Configuration["ServiceUri:TesteTecnico"]);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
