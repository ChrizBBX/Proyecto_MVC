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
    
    public partial class UDP_DetalleEnTabla_Result
    {
        public int ventaDetalle_Id { get; set; }
        public int ventaId { get; set; }
        public int productoId { get; set; }
        public int ventaDetalle_catidad { get; set; }
        public decimal ventaDetalle_Precio { get; set; }
        public System.DateTime ventaDetalle_FechaCreacion { get; set; }
        public int ventaDetalle_UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> ventaDetalle_FechaModificacion { get; set; }
        public Nullable<int> ventaDetalle_UsuarioModificacion { get; set; }
        public bool ventaDetalle_Estado { get; set; }
        public string productoNombre { get; set; }
    }
}
