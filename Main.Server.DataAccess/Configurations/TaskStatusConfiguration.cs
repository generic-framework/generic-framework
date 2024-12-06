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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);
        }
    }
}
