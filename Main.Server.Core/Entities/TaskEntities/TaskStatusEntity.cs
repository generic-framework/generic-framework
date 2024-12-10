using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.Entities.TaskEntities
{
    public class TaskStatusEntity : BaseEntity
    {
        public string StatusName { get; set; }

        public int? StatusPosition { get; set; }

        public ICollection<TaskEntity>? TaskEntities { get; set; }
    }
}
