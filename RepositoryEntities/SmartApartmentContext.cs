using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class SmartApartmentContext : DbContext
    {
        public SmartApartmentContext()
        {

        }

        public DbSet<Property> Properties { get; set; }
    }
}
