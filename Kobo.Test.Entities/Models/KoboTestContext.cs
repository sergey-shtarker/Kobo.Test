using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Kobo.Test.Entities.Models.Mapping;

namespace Kobo.Test.Entities.Models
{
    public partial class KoboTestContext : DbContext
    {
        static KoboTestContext()
        {
            Database.SetInitializer<KoboTestContext>(null);
        }

        public KoboTestContext()
            : base("Name=KoboTestContext")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new SupplierMap());
        }
    }
}
