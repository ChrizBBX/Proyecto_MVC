using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(tbDepartamentosMetaData))]
    public partial class tbDepartamentos
    {

    }
    public class tbDepartamentosMetaData
    {
        [Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Id Departamento")]
        public string departamentoId { get; set; }
        [Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Departamento")]
        public string departamentoNombre { get; set; }
        //[Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Fecha Creación")]
        public System.DateTime departamentoFechaCreacion { get; set; }
        [Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Usuario Creación")]
        public int departamentoUsuarioCreacion { get; set; }
        //[Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Fecha Modificación")]
        public Nullable<System.DateTime> departamentoFechaModificacion { get; set; }
        //[Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Usuario Mod")]
        public Nullable<int> departamentoUsuarioModificacion { get; set; }
        //[Required(ErrorMessage = "EL campo {0} es requerido")]
        [Display(Name = "Estado")]
        public bool departamentoEstado { get; set; }
    }
}