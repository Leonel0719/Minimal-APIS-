using LADCH.API.Models.EN;
using Microsoft.EntityFrameworkCore;

namespace LADCH.API.Models.DAL
{
    public class LADCHContext : DbContext
    {
        public LADCHContext(DbContextOptions<LADCHContext> options) : base(options)
        {

        }
        public DbSet<Producto> productos { get; set; }
    }
}
