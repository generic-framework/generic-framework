using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.DTOs.DepartmentDTOs;
using Main.Server.Core.DTOs.RoleDTOs;
using Main.Server.Core.Entities.DepartmentEntities;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.DTOs.UserDTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int? RoleId { get; set; }

        public int DepartmentId { get; set; }

        public RoleDto? Role { get; set; }

        public DepartmentDto? Department { get; set; }

        public List<TaskUser>? TaskUsers { get; set; }

        public List<ProjectUser>? ProjectUsers { get; set; } // Çoktan çoğa ilişki için
    }
}
