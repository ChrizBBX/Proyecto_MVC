using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(tbCargosMetaData))]
    public partial class tbCargos
    {
    }
    public class tbCargosMetaData
    {
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Id")]
        public int cargoId { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Nombre")]
        public string cargoNombre { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Fecha de Creación")]
        public System.DateTime cargoFechaCreacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Usuario Creación")]
        
        public int cargoUsuarioCreacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Fecha Modificación")]
        public Nullable<System.DateTime> cargoFechaModificacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Usuario Creacion")]
        public Nullable<int> cargoUsuarioModificacion { get; set; }
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [Display(Name = "Estado")]
        public bool cargoEstado { get; set; }

    }
}