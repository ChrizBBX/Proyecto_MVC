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
    
    public partial class tbClientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbClientes()
        {
            this.tbventa = new HashSet<tbventa>();
        }
    
        public int clienteId { get; set; }
        public string clienteNombre { get; set; }
        public string clienteApellido { get; set; }
        public string municipioId { get; set; }
        public string clienteDireccionExacta { get; set; }
        public string clienteTelefono { get; set; }
        public string clienteCorreoElectronico { get; set; }
        public System.DateTime clienteFechaCreacion { get; set; }
        public int clienteUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> clienteFechaModificacion { get; set; }
        public Nullable<int> clienteUsuarioModificacion { get; set; }
        public bool clienteEstado { get; set; }
    
        public virtual tbMunicipios tbMunicipios { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventa> tbventa { get; set; }
    }
}
