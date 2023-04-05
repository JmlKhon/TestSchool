using Microsoft.EntityFrameworkCore;
using TestSchool.Models;
using TestSchool.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var config = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<SchoolDbContext>(option => option.UseNpgsql(config["Connect"]));
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<SchoolDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
