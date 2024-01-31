using DinetAppPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace DinetAppPrueba.DataAccess.Data
{
    public class AppDBContext:DbContext
    {
        public DbSet<TarjetaCredito> tarjetacredito { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }
    }
}
