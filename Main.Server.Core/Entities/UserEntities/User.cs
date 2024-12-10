using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.DepartmentEntities;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.Entities.UserEntities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public int RoleId { get; set; }

        public int DepartmentId { get; set; }

        public Role? Role { get; set; }

        public Department? Department { get; set; }

        public ICollection<TaskUser>? TaskUsers { get; set; }

        public ICollection<ProjectUser>? ProjectUsers { get; set; } // Çoktan çoğa ilişki için


    }
}
