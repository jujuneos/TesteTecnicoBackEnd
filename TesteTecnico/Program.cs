using Microsoft.EntityFrameworkCore;
using TesteTecnico.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connection));

builder.Services.AddHttpsRedirection(options => 
{
    options.HttpsPort = 44342;
});

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
