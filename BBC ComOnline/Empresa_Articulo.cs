//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BBC_ComOnline
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empresa_Articulo
    {
        public string EmpresaRut { get; set; }
        public string EAN_ID { get; set; }
        public string Codigo_Interno { get; set; }
        public Nullable<int> Unidad_MedidaId { get; set; }
        public Nullable<int> CategoriaId { get; set; }
        public decimal Precio_Publico { get; set; }
        public decimal Precio_Costo { get; set; }
        public decimal Cantidad { get; set; }
        public Nullable<System.DateTime> Fecha_Compra { get; set; }
        public decimal IVA { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Articulo Articulo { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Unidad_Medida Unidad_Medida { get; set; }
    }
}