﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Enums;

namespace Main.Server.Core.DTOs.ProjectDTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public int? ProjectTypeId { get; set; }// Kanban Scrum Planlama

        public ProjectType? ProjectType { get; set; }

        public List<TaskEntity>? ProjectTasks { get; set; }
    }
}