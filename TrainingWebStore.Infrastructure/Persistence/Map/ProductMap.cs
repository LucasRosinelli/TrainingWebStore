using System.Data.Entity.ModelConfiguration;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Infrastructure.Persistence.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            this.ToTable("Products");

            this.HasKey(x => x.Id);

            this.Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            this.Property(x => x.Description)
                .HasMaxLength(1024)
                .IsRequired();
            this.Property(x => x.Price)
                .IsRequired();
            this.Property(x => x.QuantityOnHand)
                .IsRequired();

            this.HasRequired(x => x.Category);
        }
    }
}