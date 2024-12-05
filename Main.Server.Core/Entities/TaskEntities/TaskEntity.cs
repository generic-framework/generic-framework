using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Entities.TaskEntities
{
    public class TaskEntity : BaseEntity
    {
        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public int? ProjectId { get; set; }

        public int? TaskStatuId { get; set; }

        public int? DeparmentId { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public ICollection<TaskFile>? Files { get; set; }

    }
}
