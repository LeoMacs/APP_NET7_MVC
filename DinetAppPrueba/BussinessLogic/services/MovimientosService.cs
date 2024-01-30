using DinetAppPrueba.BussinessLogic.interfaces;
using DinetAppPrueba.DataAccess.Interfaces;
using DinetAppPrueba.Models;

namespace DinetAppPrueba.BussinessLogic.services
{
    public class MovimientosService : IMovimientosService
    {
        private readonly IMovimientos _movimientoRepository;

        public MovimientosService(IMovimientos movimientoRepository)
        {
            _movimientoRepository = movimientoRepository;
        }

        public async Task<dynamic> getMovimientos(filtros filtros)
        {
            return await _movimientoRepository.getMovimientos(filtros);
        }

        public async Task<dynamic> getMovimientoxUNIDAD(MovInventario obj)
        {
            return await _movimientoRepository.getMovimientoxUNIDAD(obj);
        }


        public async Task<int> InsertMovimientos(MovInventario obj)
        {
            return await _movimientoRepository.InsertMovimientos(obj);
        }

        public async Task<int> EditMovimientos(MovInventario obj)
        {
            return await _movimientoRepository.EditMovimientos(obj);
        }  

    }
}
