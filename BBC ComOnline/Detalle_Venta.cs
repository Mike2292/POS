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
    
    public partial class Detalle_Venta
    {
        public string Id { get; set; }
        public string VentaId { get; set; }
        public string ArticuloEAN { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Cantidad { get; set; }
        public decimal SubTotal { get; set; }
    
        public virtual Venta Venta { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}
