using DinetAppPrueba.DataAccess.Data;
using DinetAppPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DinetAppPrueba.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly AppDBContext appDBContext;

        public TarjetaController(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

    

        // GET: TarjetaController
        public ActionResult PanelTarjetas()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTarjetas()
        {
            try
            {
                var listTarjetas = await appDBContext.tarjetacredito.ToListAsync();
                return Ok(listTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTarjeta(int id)
        {
            try
            {
                TarjetaCredito tarjeta = new TarjetaCredito();
                tarjeta= await appDBContext.tarjetacredito.FirstOrDefaultAsync(x => x.idTarjeta == id) ?? new TarjetaCredito();
                return Ok(tarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTarjeta([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                appDBContext.Add(tarjeta);
                await appDBContext.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditTarjeta([FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                appDBContext.Update(tarjeta);
                await appDBContext.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTarjeta(int id)
        {
            try
            {
                var tarjeta = await appDBContext.tarjetacredito.FindAsync(id);
                if (tarjeta == null)
                {
                    return NotFound();
                }
                appDBContext.Remove(tarjeta);
                await appDBContext.SaveChangesAsync();
                return Ok(tarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
