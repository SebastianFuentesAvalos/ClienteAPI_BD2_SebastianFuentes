using ClienteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Data
{
    public class BdClientesContext : DbContext
    {
        public BdClientesContext(DbContextOptions<BdClientesContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }  // <-- Aquí define tu DbSet
    }
}
