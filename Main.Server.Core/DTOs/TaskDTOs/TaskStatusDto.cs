using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.DTOs.TaskDTOs
{
    public class TaskStatusDto
    {

        public int Id { get; set; }

        public string StatusName { get; set; }

        public int? StatusPosition { get; set; }
    }
}
