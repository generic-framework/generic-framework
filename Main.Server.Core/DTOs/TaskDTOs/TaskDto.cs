
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.Entities;

namespace Main.Server.Core.DTOs
{
    public class TaskDto
    {
        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public int? ProjectId { get; set; }

        public int? TaskStatuId { get; set; }

        public int? DeparmentId { get; set; }

        public int? UserId { get; set; }

        public List<TaskFile>? Files { get; set; }
    }
}
