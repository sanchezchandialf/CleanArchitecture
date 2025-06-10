
using Microsoft.EntityFrameworkCore;
using CA_EnterpriseLayer;
using CA_InterfaceAdapters_Models;
namespace CA_InterfaceAdapters_Data
{
    public class AppDbContext :  DbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            : base(options)
        { }
        public  DbSet<BeerModel>Beers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beer>().ToTable("Beer");
        }
    }
}
