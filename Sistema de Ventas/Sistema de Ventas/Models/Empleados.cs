using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(EmpleadosMetaData))]
    public partial class Empleados
    {
    }
    
    public class EmpleadosMetaData
    {
        [Display(Name = "Empleado Id")]
        public int empleadoId { get; set; }
        [Display(Name = "Nombre de Empleado")]
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