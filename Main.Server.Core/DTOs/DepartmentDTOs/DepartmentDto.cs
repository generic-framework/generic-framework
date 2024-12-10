using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.DTOs.UserDTOs;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.DTOs.DepartmentDTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public List<UserDto>? Users { get; set; }
    }
}
