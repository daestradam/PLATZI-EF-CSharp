using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoEF;
using proyectoEF.Models;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", async([FromServices] TareasContext dbContext) => 
{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria).Where(p => p.PrioridadTarea==proyectoEF.Models.Prioridad.Baja));
});

app.MapGet("/api/categorias", async([FromServices] TareasContext dbContext) => 
{
    return Results.Ok(dbContext.Categorias.Where(p => p.Peso==20));
});

app.Run();
