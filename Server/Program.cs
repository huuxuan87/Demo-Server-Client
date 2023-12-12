using Microsoft.EntityFrameworkCore;
using Server.Hubs;
using Server.Models;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Database
services.AddDbContext<VNVCTestContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
services.AddScoped<INguoiChoiService, NguoiChoiService>();
services.AddScoped<IDatSoService, DatSoService>();
services.AddScoped<IVNVCTestContextProcedures, VNVCTestContextProcedures>();
services.AddSingleton(c => new Random());
services.AddSingleton(c => new MonHubStore());

//services.AddControllers();
services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddSignalR();
services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.SetIsOriginAllowed((host) => true)
            .AllowAnyHeader()
            .WithMethods("GET", "POST")
            .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllers();

app.UseCors("CorsPolicy");
app.MapHub<MonHub>("/monHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
