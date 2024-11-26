using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.DTOs.RoleDTOs;
using Main.Server.Core.Entities.RoleEntities;

namespace Main.Server.Core.DTOs.UserDTOs
{
    public class UserDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int? RoleId { get; set; }

        public RoleDto? Role { get; set; }


    }
}
