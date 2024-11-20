using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.RoleProp.RoleEntites;

namespace Main.Server.Core.Entities.UserProp.UserEntities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public int? RoleId { get; set; }

        public Role? Role { get; set; }

        public int DepartmentId { get; set; }

        public int GroupId { get; set; }
    }
}
