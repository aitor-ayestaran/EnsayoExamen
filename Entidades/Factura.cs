namespace Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            FacturasProductos = new HashSet<FacturasProducto>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(8)]
        public string Numero { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public long ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasProducto> FacturasProductos { get; set; }
    }
}
