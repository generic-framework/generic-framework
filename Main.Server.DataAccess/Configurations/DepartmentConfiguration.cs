using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.DepartmentEntities;
using Main.Server.Core.Entities.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Server.DataAccess.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Primary Key
            builder.HasKey(d => d.Id);

            // Id Property
            builder.Property(d => d.Id).UseIdentityColumn();

            // DepartmentName Property
            builder.Property(d => d.DepartmentName)
                   .HasMaxLength(100)
                   .IsRequired();

            // Description Property
            builder.Property(d => d.Description)
                   .HasMaxLength(250);

            // Relationship: Department -> Users
            builder.HasMany(d => d.Users)       // Bir Department'ın birden fazla User'ı olabilir
                   .WithOne(u => u.Department) // Her User yalnızca bir Department'a bağlıdır
                   .HasForeignKey(u => u.DepartmentId) // Foreign Key: DepartmentId
                   .OnDelete(DeleteBehavior.Restrict); // Department silindiğinde User'lar korunur
        }
    }
}
