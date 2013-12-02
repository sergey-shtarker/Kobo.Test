using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kobo.Test.Entities.Models.Mapping
{
    public class SupplierMap : EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Telephone)
                .HasMaxLength(12);

            this.Property(t => t.ContactManager)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Supplier");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.ContactManager).HasColumnName("ContactManager");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithOptional(t => t.Supplier);

        }
    }
}
