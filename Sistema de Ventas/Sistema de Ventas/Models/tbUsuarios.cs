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
    using System.Collections.Generic;
    
    public partial class tbUsuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbUsuarios()
        {
            this.tbCargos = new HashSet<tbCargos>();
            this.tbCargos1 = new HashSet<tbCargos>();
            this.tbCategoria = new HashSet<tbCategoria>();
            this.tbCategoria1 = new HashSet<tbCategoria>();
            this.tbClientes = new HashSet<tbClientes>();
            this.tbClientes1 = new HashSet<tbClientes>();
            this.tbCompraDetalles = new HashSet<tbCompraDetalles>();
            this.tbCompraDetalles1 = new HashSet<tbCompraDetalles>();
            this.tbCompras = new HashSet<tbCompras>();
            this.tbCompras1 = new HashSet<tbCompras>();
            this.tbDepartamentos = new HashSet<tbDepartamentos>();
            this.tbDepartamentos1 = new HashSet<tbDepartamentos>();
            this.tbEmpleados = new HashSet<tbEmpleados>();
            this.tbEmpleados1 = new HashSet<tbEmpleados>();
            this.tbEstadosCiviles = new HashSet<tbEstadosCiviles>();
            this.tbEstadosCiviles1 = new HashSet<tbEstadosCiviles>();
            this.tbMetodoPago = new HashSet<tbMetodoPago>();
            this.tbMetodoPago1 = new HashSet<tbMetodoPago>();
            this.tbMunicipios = new HashSet<tbMunicipios>();
            this.tbMunicipios1 = new HashSet<tbMunicipios>();
            this.tbProductos = new HashSet<tbProductos>();
            this.tbProductos1 = new HashSet<tbProductos>();
            this.tbProveedores = new HashSet<tbProveedores>();
            this.tbProveedores1 = new HashSet<tbProveedores>();
            this.tbUsuarios1 = new HashSet<tbUsuarios>();
            this.tbUsuarios11 = new HashSet<tbUsuarios>();
            this.tbventa = new HashSet<tbventa>();
            this.tbventa1 = new HashSet<tbventa>();
            this.tbventaDetalles = new HashSet<tbventaDetalles>();
            this.tbventaDetalles1 = new HashSet<tbventaDetalles>();
        }
    
        public int usuarioId { get; set; }
        public string usuarioUsuario { get; set; }
        public string usuarioContrasenia { get; set; }
        public int empleadoId { get; set; }
        public int usuarioUsuarioCreacion { get; set; }
        public System.DateTime usuarioFechaCreacion { get; set; }
        public Nullable<int> usuarioUsuarioModificacion { get; set; }
        public Nullable<System.DateTime> usuarioFechaModificacion { get; set; }
        public bool usuarioEstado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCargos> tbCargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCargos> tbCargos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCategoria> tbCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCategoria> tbCategoria1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbClientes> tbClientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbClientes> tbClientes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCompraDetalles> tbCompraDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCompraDetalles> tbCompraDetalles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCompras> tbCompras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCompras> tbCompras1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDepartamentos> tbDepartamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbDepartamentos> tbDepartamentos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEmpleados> tbEmpleados1 { get; set; }
        public virtual tbEmpleados tbEmpleados2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEstadosCiviles> tbEstadosCiviles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbEstadosCiviles> tbEstadosCiviles1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMetodoPago> tbMetodoPago { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMetodoPago> tbMetodoPago1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMunicipios> tbMunicipios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbMunicipios> tbMunicipios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProductos> tbProductos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProductos> tbProductos1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProveedores> tbProveedores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbProveedores> tbProveedores1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbUsuarios> tbUsuarios1 { get; set; }
        public virtual tbUsuarios tbUsuarios2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbUsuarios> tbUsuarios11 { get; set; }
        public virtual tbUsuarios tbUsuarios3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventa> tbventa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventa> tbventa1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventaDetalles> tbventaDetalles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbventaDetalles> tbventaDetalles1 { get; set; }
    }
}
