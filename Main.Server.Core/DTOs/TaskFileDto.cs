using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.DTOs
{
    public class TaskFileDto
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long? FileSize { get; set; }
        public int? TaskId { get; set; }
        public TaskDto? TaskDto { get; set; }
    }
}
