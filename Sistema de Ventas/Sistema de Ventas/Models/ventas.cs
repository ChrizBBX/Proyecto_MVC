using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_Ventas.Models
{

    [MetadataType(typeof(ventasMetaData))]
    public partial class ventas
    {
    }

    public class ventasMetaData
    {
        public int ventaId { get; set; }
        [Display(Name = "Cliente ID")]
        public int clienteId { get; set; }
        [Display(Name = "Fecha de venta")]
        public System.DateTime ventaFecha { get; set; }
        [Display(Name = "Nombre de empleado")]
        public int empleadoId { get; set; }
        [Display(Name = "Metodo de Pago")]
        public string metodopagoId { get; set; }
        public System.DateTime ventaFechaCreacion { get; set; }
        public int ventaUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> ventaFechaModificacion { get; set; }
        public Nullable<int> ventaUsuarioModificacion { get; set; }
        public bool ventaEstado { get; set; }

        public virtual tbClientes tbClientes { get; set; }
        public virtual tbEmpleados tbEmpleados { get; set; }
        public virtual tbMetodoPago tbMetodoPago { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventaDetalles> tbventaDetalles { get; set; }
    }
}