using Microsoft.EntityFrameworkCore;
using Server.Commons;
using Server.Models;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<INguoiChoiService, NguoiChoiService>();
services.AddScoped<IDatSoService, DatSoService>();
services.AddScoped<IVNVCTestContextProcedures,  VNVCTestContextProcedures>();
services.AddSingleton(c => new SecureRandom());

// Database
builder.Services.AddDbContext<VNVCTestContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
