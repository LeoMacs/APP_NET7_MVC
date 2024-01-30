﻿using DinetAppPrueba.Models;

namespace DinetAppPrueba.DataAccess.Interfaces
{
    public interface IMovimientos
    {

        public Task<dynamic> getMovimientos(filtros filtros);
        public Task<dynamic> getMovimientoxUNIDAD(MovInventario obj);
        public Task<int> InsertMovimientos(MovInventario obj);
        public Task<int> EditMovimientos(MovInventario obj);
    }
}
