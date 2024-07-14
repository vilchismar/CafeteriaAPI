using Microsoft.EntityFrameworkCore;
using CafeteriaApi.Models;

namespace CafeteriaApi.Data
{
    public class CafeteriaContext : DbContext
    {
        public CafeteriaContext(DbContextOptions<CafeteriaContext> options) : base(options) { }

        public DbSet<TbHccOrdenes> Ordenes { get; set; } = null!;
        public DbSet<TbHccOrdenesDetalle> OrdenesDetalle { get; set; } = null!;
        public DbSet<TbHccProductos> Productos { get; set; } = null!;
        public DbSet<TbHccAlmacen> Almacen { get; set; } = null!;
        public DbSet<TbHccCatEstatusOrden> CatEstatusOrden { get; set; } = null!;
        public DbSet<TbHccMesas> Mesas { get; set; } = null!;
    }
}
