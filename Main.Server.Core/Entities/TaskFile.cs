using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.Entities
{
    public class TaskFile: BaseEntity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public long? FileSize { get; set; } 
        public int? TaskId { get; set; }
        public TaskEntity? TaskEntity { get; set; }

    }
}
