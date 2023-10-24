using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_ForoUnidad1.Entities
{
    [Table("valoraciones")]
    public class Valoracion
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("puntuacion")]
        [Required]
        public int Puntuacion { get; set; }

        [Column("comentario")]
        [StringLength(100)]
        [Required]
        public string Comentario { get; set; }

        [Column("producto_id")]
        [Required]
        public int ProductoId { get; set; }

        //[ForeignKey(nameof(ProductoId))]
        //[NotMapped]
        //public virtual Producto? Producto { get; set; }
    }
}
