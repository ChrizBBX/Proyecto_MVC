using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(tbEmpleadosMetaData))]
    public partial class tbEmpleados
    {
    }
    public class tbEmpleadosMetaData
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Id")]
        public int empleadoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombres")]
        public string empleadoNombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Apellidos")]
        public string empleadoApellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Sexo")]
        //[RegularExpression("f|m", ErrorMessage = "solo m o f")]
        public string empleadoSexo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Municipio")]
        public string municipioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Dirección")]
        public string empleadoDireccionExacta { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado Civil")]
        public string estadoCivilId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Telefono")]
        public string empleadoTelefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Correo Electronico")]
        public string empleadoCorreoElectronico { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public System.DateTime empleadoFechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Contratación")]
        public System.DateTime empleadoFechaContratacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cargo")]
        public int cargoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Crea")]
        public System.DateTime empleadoFechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario Crea")]
        public int empleadoUsuarioCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Mod")]
        public Nullable<System.DateTime> empleadoFechaModificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Mod")]
        public Nullable<int> empleadoUsuarioModificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public bool empleadoEstado { get; set; }
    }
}