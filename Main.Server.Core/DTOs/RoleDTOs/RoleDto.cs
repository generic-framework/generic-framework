using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.DTOs.RoleDTOs
{
    public class RoleDto : BaseDto
    {
        public int RoleName { get; set; }

        public bool IsActive { get; set; }

        public List<User> Users { get; set; }
    }
}
