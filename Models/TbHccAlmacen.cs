using System.ComponentModel.DataAnnotations;

namespace CafeteriaApi.Models
{
    public class TbHccAlmacen
    {
        [Key]
        public int AlmId { get; set; }
        public int AlmCantidad { get; set; }
        public DateTime AlmFechaActualizacion { get; set; }
        public byte AlmEstatus { get; set; }
    }
}
