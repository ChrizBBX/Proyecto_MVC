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
    
    public partial class UDP_BuscarProveedores_Result
    {
        public int proveedorId { get; set; }
        public string proveedorNombre { get; set; }
        public string municipioId { get; set; }
        public string municipioNombre { get; set; }
        public string proveedorDireccionExacta { get; set; }
        public string proveedorTelefono { get; set; }
        public string proveedorEmail { get; set; }
        public System.DateTime proveedorFechaCreacion { get; set; }
        public int proveedorUsuarioCreacion { get; set; }
        public Nullable<System.DateTime> proveedorFechaModificacion { get; set; }
        public Nullable<int> proveedorUsuarioModificacion { get; set; }
        public bool proveedorEstado { get; set; }
    }
}