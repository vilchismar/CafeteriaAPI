using System.ComponentModel.DataAnnotations;

namespace CafeteriaApi.Models
{
    public class TbHccMesas
    {
        [Key]
        public int MesId { get; set; }
        public int MesLugares { get; set; }
        public byte MesDisponible { get; set; }
        public byte MesEstatus { get; set; }
    }
}
