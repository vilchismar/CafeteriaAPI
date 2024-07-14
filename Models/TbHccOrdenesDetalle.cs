using System.ComponentModel.DataAnnotations;

namespace CafeteriaApi.Models
{
    public class TbHccOrdenesDetalle
    {
        [Key]
        public int OrdDetId { get; set; }
        public int OrdId { get; set; }
        public int ProId { get; set; }
        public int OrdDetCantidad { get; set; }
        public byte OrdDetEstatus { get; set; }
        
        // Navigation properties
        public TbHccOrdenes? Orden { get; set; }
        public TbHccProductos? Producto { get; set; }
    }
}
