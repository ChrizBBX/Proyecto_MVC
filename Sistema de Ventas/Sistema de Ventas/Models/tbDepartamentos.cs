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
    
    public partial class tbDepartamentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbDepartamentos()
        {
            this.tbMunicipios = new HashSet<tbMunicipios>();
        }
    
        public string departamentoId { get; set; }
        public string departamentoNombre { get; set; }
        public System.DateTime departamentoFechaCreacion { get; set; }
        public int departamentoUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> departamentoFechaModificacion { get; set; }
        public Nullable<int> departamentoUsuarioModificacion { get; set; }
        public bool departamentoEstado { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMunicipios> tbMunicipios { get; set; }
    }
}
