using System.Data.Entity.ModelConfiguration;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Infrastructure.Persistence.Map
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("Categories");

            this.HasKey(x => x.Id);

            this.Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}