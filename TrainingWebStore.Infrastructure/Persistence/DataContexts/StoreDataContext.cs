using System.Data.Entity;
using TrainingWebStore.Domain.Entities;
using TrainingWebStore.Infrastructure.Persistence.Map;

namespace TrainingWebStore.Infrastructure.Persistence.DataContexts
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext()
            : base("StoreConnectionString")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
        }
    }
}