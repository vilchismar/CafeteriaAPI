using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CafeteriaApi.Data;
using CafeteriaApi.Models;

namespace CafeteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly CafeteriaContext _context;

        public OrdenesController(CafeteriaContext context)
        {
            _context = context;
        }

        [HttpGet("total-ordenes")]
        public async Task<IActionResult> GetTotalOrdenes()
        {
            try
            {
                var totalOrdenes = await _context.Ordenes
                    .Include(o => o.Mesa)
                    .Select(o => new { o.OrdId, o.MesId })
                    .ToListAsync();

                return Ok(new
                {
                    estatus = 200,
                    mensaje = "Total de órdenes y las mesas correspondientes.",
                    codigo = 1,
                    datos = totalOrdenes
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    estatus = 500,
                    mensaje = ex.Message,
                    codigo = -1
                });
            }
        }

        [HttpGet("mesas-disponibles")]
        public async Task<IActionResult> GetMesasDisponibles()
        {
            try
            {
                var mesasDisponibles = await _context.Mesas
                    .Where(m => m.MesDisponible == 1)
                    .Select(m => new { m.MesId, m.MesLugares })
                    .ToListAsync();

                return Ok(new
                {
                    estatus = 200,
                    mensaje = "Mesas disponibles y cantidad de lugares por mesa.",
                    codigo = 1,
                    datos = mesasDisponibles
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    estatus = 500,
                    mensaje = ex.Message,
                    codigo = -1
                });
            }
        }

        [HttpPost("nueva-orden")]
        public async Task<IActionResult> InsertarOrden([FromBody] TbHccOrdenes nuevaOrden)
        {
            try
            {
                _context.Ordenes.Add(nuevaOrden);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    estatus = 200,
                    mensaje = "Nueva orden insertada correctamente.",
                    codigo = 1
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    estatus = 500,
                    mensaje = ex.Message,
                    codigo = -1
                });
            }
        }

        [HttpPut("actualizar-orden/{id}")]
        public async Task<IActionResult> ActualizarOrden(int id, [FromBody] TbHccOrdenes ordenActualizada)
        {
            try
            {
                var orden = await _context.Ordenes.FindAsync(id);
                if (orden == null)
                {
                    return Ok(new
                    {
                        estatus = 500,
                        mensaje = "Orden no encontrada.",
                        codigo = -1
                    });
                }

                orden.CatOrdId = ordenActualizada.CatOrdId;
                orden.OrdEstatus = ordenActualizada.OrdEstatus;
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    estatus = 200,
                    mensaje = "Orden actualizada correctamente.",
                    codigo = 1
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    estatus = 500,
                    mensaje = ex.Message,
                    codigo = -1
                });
            }
        }

        [HttpDelete("eliminar-orden/{id}")]
        public async Task<IActionResult> EliminarOrden(int id)
        {
            try
            {
                var orden = await _context.Ordenes.FindAsync(id);
                if (orden == null)
                {
                    return Ok(new
                    {
                        estatus = 500,
                        mensaje = "Orden no encontrada.",
                        codigo = -1
                    });
                }

                orden.OrdEstatus = 0; // Borrado lógico
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    estatus = 200,
                    mensaje = "Orden eliminada (borrado lógico) correctamente.",
                    codigo = 1
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    estatus = 500,
                    mensaje = ex.Message,
                    codigo = -1
                });
            }
        }
    }
}
