using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.DTOs.ProjectDTOs
{
    public class ProjectUserDto
    {
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }


    }
}
