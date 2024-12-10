using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.TaskEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Server.DataAccess.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Id Property
            builder.Property(x => x.Id).UseIdentityColumn();

            // Status Property
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status == true); // Sadece aktif görevler

            // TaskTitle Property
            builder.Property(x => x.TaskTitle)
                   .HasMaxLength(200)
                   .IsRequired();

            // TaskDescription Property
            builder.Property(x => x.TaskDescription)
                   .HasMaxLength(1000);

            // Relationship: Task -> Project
            builder.HasOne(x => x.Project)
                   .WithMany(p => p.ProjectTasks)
                   .HasForeignKey(x => x.ProjectId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relationship: Task -> TaskStatus
            builder.HasOne(x => x.TaskStatus)
                   .WithMany(ts => ts.TaskEntities)
                   .HasForeignKey(x => x.TaskStatuId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relationship: Task -> MainTask (Self-referencing)
            builder.HasOne(x => x.MainTask)
                   .WithMany()
                   .HasForeignKey(x => x.MainTaskId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
