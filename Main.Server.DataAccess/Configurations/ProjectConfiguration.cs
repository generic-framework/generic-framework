using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.ProjectEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Server.DataAccess.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Id Property
            builder.Property(x => x.Id).UseIdentityColumn();

            // Status Property
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasQueryFilter(x => x.Status);

            // ProjectName Property
            builder.Property(x => x.ProjectName)
                   .HasMaxLength(100)
                   .IsRequired();

            // ProjectType Enum Mapping
            builder.Property(x => x.ProjectTypeId)
                   .IsRequired(); // ProjectTypeId zorunlu olsun

            builder.HasQueryFilter(x => x.Status == true); // Global query filter burada


            // Relationship: Project -> TaskEntity
            builder.HasMany(p => p.ProjectTasks)       // Bir Project'in birden fazla TaskEntity'si olabilir
                   .WithOne(t => t.Project)           // Her TaskEntity yalnızca bir Project'e bağlıdır
                   .HasForeignKey(t => t.ProjectId)   // Foreign Key: ProjectId
                   .OnDelete(DeleteBehavior.Cascade); // Project silindiğinde ilişkili TaskEntity'ler de silinir

            builder.HasMany(p => p.ProjectUsers)
               .WithOne(pu => pu.Project)
               .HasForeignKey(pu => pu.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
