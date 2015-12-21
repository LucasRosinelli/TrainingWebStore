using System.Data.Entity.ModelConfiguration;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Infrastructure.Persistence.Map
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            this.ToTable("Orders");

            this.HasKey(x => x.Id);

            this.Property(x => x.Date)
                .IsRequired();
            this.Property(x => x.Status)
                .IsRequired();
            this.Ignore(x => x.Total);

            this.HasRequired(x => x.User);
            this.HasMany(x => x.OrderItems)
                .WithRequired(x => x.Order);
        }
    }
}