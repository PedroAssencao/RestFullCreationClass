using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestFullAPIMVC.API.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbSistemaAcademicoContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-02BUU56;Initial Catalog=DbSistemaAcademico;Integrated Security=True;Encrypt=False;");
});

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
