using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(tbMunicipiosMetaData))]
    public partial class tbMunicipios
    {
    }

    public class tbMunicipiosMetaData
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Id")]
        public string municipioId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Departamento")]
        public string departamentoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Municipio")]
        public string municipioNombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Creación")]
        public System.DateTime municipioFechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario Creación")]
        public int municipioUsuarioCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Modificacion")]
        public Nullable<System.DateTime> municipioFechaModificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario Modificación")]
        public Nullable<int> municipioUsuarioModificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public bool municipioEstado { get; set; }
    }
}