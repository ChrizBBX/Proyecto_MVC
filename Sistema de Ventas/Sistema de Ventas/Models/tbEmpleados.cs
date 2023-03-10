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
    
    public partial class tbEmpleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEmpleados()
        {
            this.tbUsuarios2 = new HashSet<tbUsuarios>();
            this.tbventa = new HashSet<tbventa>();
        }
    
        public int empleadoId { get; set; }
        public string empleadoNombre { get; set; }
        public string empleadoApellido { get; set; }
        public string empleadoSexo { get; set; }
        public string municipioId { get; set; }
        public string empleadoDireccionExacta { get; set; }
        public string estadoCivilId { get; set; }
        public string empleadoTelefono { get; set; }
        public string empleadoCorreoElectronico { get; set; }
        public System.DateTime empleadoFechaNacimiento { get; set; }
        public System.DateTime empleadoFechaContratacion { get; set; }
        public int cargoId { get; set; }
        public System.DateTime empleadoFechaCreacion { get; set; }
        public int empleadoUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> empleadoFechaModificacion { get; set; }
        public Nullable<int> empleadoUsuarioModificacion { get; set; }
        public bool empleadoEstado { get; set; }
    
        public virtual tbCargos tbCargos { get; set; }
        public virtual tbEstadosCiviles tbEstadosCiviles { get; set; }
        public virtual tbMunicipios tbMunicipios { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbUsuarios> tbUsuarios2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventa> tbventa { get; set; }
    }
}
