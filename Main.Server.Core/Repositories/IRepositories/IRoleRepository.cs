﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.RoleEntities;

namespace Main.Server.Core.Repositories.IRepositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        List<Role> GetAllRoles();

    }
}
