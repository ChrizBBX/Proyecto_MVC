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
    
    public partial class UDP_LlenarProductos_Result
    {
        public int productoId { get; set; }
        public string productoNombre { get; set; }
        public decimal productoPrecio { get; set; }
        public int categoriaId { get; set; }
        public string categoriaDescripcion { get; set; }
        public int proveedorId { get; set; }
        public string proveedorNombre { get; set; }
        public int productoStock { get; set; }
        public System.DateTime productoFechaCreacion { get; set; }
        public int productoUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> productoFechaModificacion { get; set; }
        public Nullable<int> productoUsuarioModificacion { get; set; }
        public bool productoEstado { get; set; }
    }
}
