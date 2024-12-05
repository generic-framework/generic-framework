using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.ProductEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Server.DataAccess.Configurations
{
    internal class FileConfiguration : IEntityTypeConfiguration<TaskFile>
    {
        public void Configure(EntityTypeBuilder<TaskFile> builder)
        {
            builder.HasKey(f => f.Id); // Primary Key
            //builder.Property(f => f.FileName).IsRequired().HasMaxLength(255); // Zorunlu alan
            //builder.Property(f => f.FilePath).IsRequired(); // Zorunlu alan

            // Task ile ilişki
            builder.HasOne(f => f.TaskEntity)
                   .WithMany(t => t.Files)
                   .HasForeignKey(f => f.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
