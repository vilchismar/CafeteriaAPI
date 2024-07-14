using System.ComponentModel.DataAnnotations;

namespace CafeteriaApi.Models
{
    public class TbHccProductos
    {
        [Key]
        public int ProId { get; set; }
        public int AlmId { get; set; }
        public string ProNombre { get; set; } = string.Empty;
        public string ProDescripcion { get; set; } = string.Empty;
        public decimal ProPrecio { get; set; }
        public byte ProEstatus { get; set; }

        // Navigation property
        public TbHccAlmacen? Almacen { get; set; }
    }
}
