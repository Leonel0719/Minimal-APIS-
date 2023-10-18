using Microsoft.EntityFrameworkCore;
using LADCH.API.Models.EN;

namespace LADCH.API.Models.DAL
{
    public class LADCHContext : DbContext
    {
        public LADCHContext(DbContextOptions<LADCHContext> options) : base(options) 
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
