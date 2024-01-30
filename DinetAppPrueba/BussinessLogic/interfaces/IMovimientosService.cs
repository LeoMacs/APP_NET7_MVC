using DinetAppPrueba.Models;

namespace DinetAppPrueba.BussinessLogic.interfaces
{
    public interface IMovimientosService
    {
        public Task<dynamic> getMovimientos(filtros filtros);
        public Task<dynamic> getMovimientoxUNIDAD(MovInventario obj);
        public Task<int> InsertMovimientos(MovInventario obj);
        public Task<int> EditMovimientos(MovInventario obj);

    }
}
