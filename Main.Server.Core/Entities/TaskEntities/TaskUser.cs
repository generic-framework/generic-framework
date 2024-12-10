using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Entities.TaskEntities
{
    public class TaskUser
    {
        public int TaskId { get; set; }
        public TaskEntity Task { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
