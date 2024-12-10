using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Server.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            // Id Property
            builder.Property(x => x.Id).UseIdentityColumn();

            // Status Property
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);

            // Name Property
            builder.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            // Surname Property
            builder.Property(x => x.Surname)
                   .HasMaxLength(50)
                   .IsRequired();

            // Email Property
            builder.Property(x => x.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasOne(u => u.Role)
                  .WithMany(r => r.Users)
                  .HasForeignKey(u => u.RoleId)
                  .OnDelete(DeleteBehavior.Restrict);


            // Relationship: User -> Department
            builder.HasOne(x => x.Department) // Her User bir Department'a bağlı
                   .WithMany(d => d.Users)    // Her Department birden fazla User'a sahip
                   .HasForeignKey(x => x.DepartmentId) // Foreign Key: DepartmentId
                   .OnDelete(DeleteBehavior.Restrict); //
        }
    }
}
