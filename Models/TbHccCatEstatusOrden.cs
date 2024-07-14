using System.ComponentModel.DataAnnotations;

namespace CafeteriaApi.Models
{
    public class TbHccCatEstatusOrden
    {
        [Key]
        public int CatOrdId { get; set; }
        public string CatOrdNombre { get; set; } = string.Empty;
        public byte CatOrdEstatus { get; set; }
    }
}
