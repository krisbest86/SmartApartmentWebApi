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
    }
}
