using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.DTOs.TaskDTOs
{
    public class TaskStatusDto
    {

        public int Id { get; set; }

        public string StatusName { get; set; }

        public int? StatusPosition { get; set; }

        public List<TaskDto>? TaskEntities { get; set; }

    }
}
