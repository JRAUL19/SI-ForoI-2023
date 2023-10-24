using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_ForoUnidad1.Entities
{
    [Table("valoracion_promedio")]
    public class ValoracionPromedio
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [Required]
        public int ProductoId { get; set; }

        [ForeignKey(nameof(ProductoId))]
        [NotMapped]
        public virtual Producto? Producto { get; set; }

        [Column("promedio")]
        public int Promedio { get; set; }

    }
}
