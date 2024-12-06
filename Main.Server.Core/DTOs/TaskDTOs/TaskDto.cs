
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.Entities;
using Main.Server.Core.DTOs.TaskDTOs;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Enums;

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

        public int? MainTaskId { get; set; }

        public DateTime? DevelopmentCompletionDate { get; set; }

        public DateTime? ProcessingDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? PriortyTypesId { get; set; }

        public int? SubjectTypesId { get; set; }

        public SubjectTypes? SubjectTypes { get; set; }

        public PriorityTypes? PriorityTypes { get; set; }

        public TaskDto? MainTask { get; set; }

        public TaskStatusDto? TaskStatus { get; set; }

        public User? User { get; set; }

        public List<TaskFile>? Files { get; set; }
    }
}
