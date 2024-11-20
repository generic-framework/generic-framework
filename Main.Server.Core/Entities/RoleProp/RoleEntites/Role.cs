using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserProp.UserEntities;

namespace Main.Server.Core.Entities.RoleProp.RoleEntites
{
    public class Role : BaseEntity
    {
        public int RoleName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
