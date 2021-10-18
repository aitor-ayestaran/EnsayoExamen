namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductosCompletos")]
    public partial class ProductosCompleto
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "money")]
        public decimal Precio { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CategoriaId { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string CategoriaNombre { get; set; }
    }
}
