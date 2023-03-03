//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sistema_de_Ventas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbventa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbventa()
        {
            this.tbventaDetalles = new HashSet<tbventaDetalles>();
        }
    
        public int ventaId { get; set; }
        public int clienteId { get; set; }
        public System.DateTime ventaFecha { get; set; }
        public int empleadoId { get; set; }
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
