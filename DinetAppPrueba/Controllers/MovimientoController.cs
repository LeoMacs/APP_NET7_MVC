using DinetAppPrueba.BussinessLogic.interfaces;
using DinetAppPrueba.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DinetAppPrueba.Controllers
{
    public class MovimientoController : Controller
    {
        private IMovimientosService _service;

        public MovimientoController(IMovimientosService service)
        {
            _service = service;
        }

        

        public ActionResult panelMovimientos()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> getMovimientos( filtros f)
        {
            return new JsonResult(await _service.getMovimientos(f));
        }

        [HttpGet]
        public async Task<JsonResult> getMovimientosxUnidad( MovInventario obj)
        {
            return new JsonResult(await _service.getMovimientoxUNIDAD(obj));
        }


        [HttpPost]
        public async Task<JsonResult> InsertMovimiento(MovInventario obj)
        {
            return new JsonResult(await _service.InsertMovimientos(obj));
        }

        [HttpPut]
        public async Task<JsonResult> EditMovimiento( MovInventario obj)
        {
            return new JsonResult(await _service.EditMovimientos(obj));
        }



    }
}
