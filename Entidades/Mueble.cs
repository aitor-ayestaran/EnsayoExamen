namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mueble
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Column(TypeName = "money")]
        public decimal? Precio { get; set; }

        public double? Largo { get; set; }

        public double? Ancho { get; set; }

        public double? Alto { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFabricacion { get; set; }
    }
}
