using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_ForoUnidad1.Entities
{
    [Table("productos")]
    public class Producto
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Column("precio")]
        [Required]
        public decimal Precio { get; set; }

        [Column("descripcion")]
        [StringLength(100)]
        [Required]
        public string Descripcion { get; set; }

        [NotMapped]
        public virtual ICollection<Valoracion>? Valoraciones { get; set; }
    }
}
