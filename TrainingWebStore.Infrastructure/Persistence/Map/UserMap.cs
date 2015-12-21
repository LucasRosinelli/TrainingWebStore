using System.Data.Entity.ModelConfiguration;
using TrainingWebStore.Domain.Entities;

namespace TrainingWebStore.Infrastructure.Persistence.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("Users");

            this.HasKey(x => x.Id);

            this.Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();
            this.Property(x => x.Password)
                .HasMaxLength(256)
                .IsFixedLength()
                .IsRequired();
            this.Property(x => x.IsAdmin)
                .IsRequired();
        }
    }
}