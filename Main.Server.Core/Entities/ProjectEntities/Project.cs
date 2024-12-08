using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Enums;

namespace Main.Server.Core.Entities.ProjectEntities
{
    public class Project : BaseEntity
    {
        public string ProjectName { get; set; }

        public int? ProjectTypeId { get; set; }// Kanban Scrum Planlama

        public ProjectType? ProjectType { get; set; }

        public ICollection<TaskEntity>? ProjectTasks { get; set; }
    }
}
