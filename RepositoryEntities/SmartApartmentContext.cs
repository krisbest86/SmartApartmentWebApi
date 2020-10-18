using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class SmartApartmentContext : DbContext
    {
        public SmartApartmentContext()
        {

        }

        public SmartApartmentContext(DbContextOptions<SmartApartmentContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging(true)
                .UseSqlServer(@"Server=HP-KOMPUTER\SQLEXPRESS;Database=smartapartmentdb;Trusted_Connection=True");
        }
    }
}
