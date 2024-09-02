using CrudCore.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudCore.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context>options):base(options)
        {
            
        }
        public DbSet<Detail1> Details { get; set; }
    }

}
