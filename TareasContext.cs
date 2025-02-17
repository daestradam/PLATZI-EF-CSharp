using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;

namespace proyectoEF;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}

    public TareasContext(DbContextOptions<TareasContext> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        List<Categoria> categoriasInit = new();
        categoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("fefbcf75-1dc7-4e16-926c-2b6e2930011d"), Nombre="Actividades pendientes", Peso=20});
        categoriasInit.Add(new Categoria(){CategoriaId=Guid.Parse("fefbcf75-1dc7-4e16-926c-2b6e29300102"), Nombre="Actividades personales", Peso=50});

        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new();
        tareasInit.Add(new Tarea(){TareaId=Guid.Parse("fefbcf75-1dc7-4e16-926c-2b6e29300112"),CategoriaId=Guid.Parse("fefbcf75-1dc7-4e16-926c-2b6e2930011d"), PrioridadTarea=Prioridad.Media, Titulo="Pago de servicios publicos", FechaCreacion=DateTime.Now, FechaLimite=DateTime.Now.AddMonths(1)});
        tareasInit.Add(new Tarea(){TareaId=Guid.Parse("fefbcf75-1dc7-4e16-926c-2b6e29300113"),CategoriaId=Guid.Parse("fefbcf75-1dc7-4e16-926c-2b6e29300102"), PrioridadTarea=Prioridad.Baja, Titulo="Terminar de ver película", FechaCreacion=DateTime.Now, FechaLimite=DateTime.Now.AddMonths(1)});
        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p=> p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Property(p => p.FechaLimite);
            tarea.Ignore(p => p.Resumen); 

            tarea.HasData(tareasInit);
        });
    }

}