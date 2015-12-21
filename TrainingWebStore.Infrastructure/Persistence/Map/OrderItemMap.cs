using System.Data.Entity.ModelConfiguration;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Infrastructure.Persistence.Map
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            this.ToTable("OrderItems");

            this.HasKey(x => x.Id);

            this.Property(x => x.Quantity)
                .IsRequired();
            this.Property(x => x.Price)
                .IsRequired();

            this.HasRequired(x => x.Product);
            this.HasRequired(x => x.Order);
        }
    }
}