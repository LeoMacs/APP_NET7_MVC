namespace DinetAppPrueba.DataAccess.Data
{
    public class ConexionService
    {
        private readonly IConfiguration _configuration;

        public ConexionService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string getConexion()
        {
            return _configuration.GetConnectionString("BackendConexion"); 
        }
    }
}
