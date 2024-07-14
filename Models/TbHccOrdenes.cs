using System.ComponentModel.DataAnnotations;


namespace CafeteriaApi.Models
{
	public class TbHccOrdenes
	{
		[Key]
		public int OrdId { get; set; }
		public int MesId { get; set; }
		public int CatOrdId { get; set; }
		public DateTime OrdFechaInicio { get; set; }
		public byte OrdEstatus { get; set; }

		// Navigation properties
		public TbHccMesas? Mesa { get; set; }
		public TbHccCatEstatusOrden? EstatusOrden { get; set; }
		public ICollection<TbHccOrdenesDetalle>? OrdenesDetalle { get; set; }
	}
}
