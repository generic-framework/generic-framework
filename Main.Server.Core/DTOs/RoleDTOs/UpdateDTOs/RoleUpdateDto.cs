﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.DTOs.RoleDTOs.UpdateDTOs
{
    public class RoleUpdateDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
