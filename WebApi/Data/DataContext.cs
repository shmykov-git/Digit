using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
    }
}
