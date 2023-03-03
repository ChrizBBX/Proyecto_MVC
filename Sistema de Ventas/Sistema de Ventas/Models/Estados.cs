using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(tbEstadosCivilesMetaData))]
    public partial class tbEstadosCiviles
    {
    }

    public class tbEstadosCivilesMetaData
    {
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Id")]
        public string estadoCivilId { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string estadoCivilNombre { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Fecha Creación")]
        public System.DateTime estadoCivilFechaCreacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Usuario Creación")]
        public int estadoCivilUsuarioCreacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Fecha Modificación")]
        public Nullable<System.DateTime> estadoCivilFechaModificacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Usuario Modificación")]
        public Nullable<int> estadoCivilUsuarioModificacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Estado")]
        public bool estadoCivilEstado { get; set; }
    }
}