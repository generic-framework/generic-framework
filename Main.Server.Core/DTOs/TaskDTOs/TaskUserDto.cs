using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.DTOs.TaskDTOs
{
    public class TaskUserDto
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
    }
}
