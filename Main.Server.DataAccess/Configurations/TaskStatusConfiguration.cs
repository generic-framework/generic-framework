using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Server.DataAccess.Configurations
{
    public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatusEntity>
    {
        public void Configure(EntityTypeBuilder<TaskStatusEntity> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Id Property
            builder.Property(x => x.Id).UseIdentityColumn();

            // Status Property
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);

            // StatusName Property
            builder.Property(x => x.StatusName)
                   .HasMaxLength(100)
                   .IsRequired();

            // StatusPosition Property
            builder.Property(x => x.StatusPosition)
                   .IsRequired(false);

            // Relationship: TaskStatus -> TaskEntity
            builder.HasMany(ts => ts.TaskEntities)
                   .WithOne(t => t.TaskStatus)
                   .HasForeignKey(t => t.TaskStatuId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
