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
    
    public partial class tbMunicipios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbMunicipios()
        {
            this.tbClientes = new HashSet<tbClientes>();
            this.tbEmpleados = new HashSet<tbEmpleados>();
            this.tbProveedores = new HashSet<tbProveedores>();
        }
    
        public string municipioId { get; set; }
        public string departamentoId { get; set; }
        public string municipioNombre { get; set; }
        public System.DateTime municipioFechaCreacion { get; set; }
        public int municipioUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> municipioFechaModificacion { get; set; }
        public Nullable<int> municipioUsuarioModificacion { get; set; }
        public bool municipioEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbClientes> tbClientes { get; set; }
        public virtual tbDepartamentos tbDepartamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProveedores> tbProveedores { get; set; }
    }
}
