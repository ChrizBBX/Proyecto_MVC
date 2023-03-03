using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Ventas.Models
{
    [MetadataType(typeof(tbProductosMetaData))]
    public partial class tbProductos
    {
    }
    public class tbProductosMetaData
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Id Producto")]
        public int productoId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre Producto")]
        public string productoNombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Precio")]
        public decimal productoPrecio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Id Categoria")]
        public int categoriaId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Id Proveedor")]
        public int proveedorid { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Stock")]
        public int productoStock { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Creación")]
        public System.DateTime productoFechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario")]
        public int productoUsuarioCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fecha Mod")]
        public Nullable<System.DateTime> productoFechaModificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario Mod")]
        public Nullable<int> productoUsuarioModificacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public bool productoEstado { get; set; }

    }
}