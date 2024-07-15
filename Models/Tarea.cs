using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoEF.Models;

//[Table("Tarea")] //El nombre que uno quiera que quede en la DB
public class Tarea {
    //[Key]
    public Guid TareaId {get; set;}
    //[ForeignKey("CategoriaId")]
    public Guid CategoriaId {get; set;}
    //[Required]
    //[MaxLength(200, ErrorMessage="Titulo debe tener 200 carácteres o más"), MinLength(50)]
    public string Titulo {get; set;}
    public string Descripcion {get; set;}
    public Prioridad PrioridadTarea {get; set;}
    public DateTime FechaCreacion {get; set;}
    public virtual Categoria Categoria {get; set;}
    //[NotMapped]
    public string Resumen {get;set;}
}
public enum Prioridad {
    Baja,
    Media,
    Alta
}