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
    public class TaskUserConfiguration : IEntityTypeConfiguration<TaskUser>
    {
        public void Configure(EntityTypeBuilder<TaskUser> builder)
        {
            // Composite Key: TaskId + UserId
            builder.HasKey(tu => new { tu.TaskId, tu.UserId });

            // Relationship: TaskUser -> Task
            builder.HasOne(tu => tu.Task)            // TaskUser bir Task'e ait
                   .WithMany(t => t.TaskUsers)      // Task birden fazla TaskUser'a sahip
                   .HasForeignKey(tu => tu.TaskId)  // Foreign Key: TaskId
                   .OnDelete(DeleteBehavior.Cascade) // Task silinirse ilişkili TaskUser kayıtları silinir
                               .IsRequired(false); // Opsiyonel hale getirildi

            // Relationship: TaskUser -> User
            builder.HasOne(tu => tu.User)           // TaskUser bir User'a ait
                   .WithMany(u => u.TaskUsers)     // User birden fazla TaskUser'a sahip
                   .HasForeignKey(tu => tu.UserId) // Foreign Key: UserId
                   .OnDelete(DeleteBehavior.Cascade);// User silinirse ilişkili TaskUser kayıtları silinir

            builder.HasQueryFilter(tu => tu.Task != null && tu.Task.Status == true); // Sadece aktif görevler

        }
    }
}
