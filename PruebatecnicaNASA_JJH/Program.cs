using Microsoft.EntityFrameworkCore;
using PruebatecnicaNASA_JJH.App.Services;
using PruebatecnicaNASA_JJH.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAsteroidService, AsteroidService>(); // Inyección de dependecias del Service
//builder.Configuration.GetConnectionString("AsteroidEntityConnection");
builder.Services.AddDbContext<AsteroidContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AsteroidEntityConnection"))
);

var app = builder.Build();

//// Cuando se ejecuta el proyecto, crea la bd:
//using (var scope = app.Services.CreateScope())
//{
//    var dataEntityContext = scope.ServiceProvider.GetRequiredService<AsteroidContext>();
//    dataEntityContext.Database.Migrate();
//}


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
