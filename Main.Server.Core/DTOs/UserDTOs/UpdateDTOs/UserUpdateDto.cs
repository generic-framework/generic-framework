using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.DTOs.UserDTOs.UpdateDTOs
{
    public class UserUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonTitle { get; set; }

        public int? RoleId { get; set; }

    }
}
