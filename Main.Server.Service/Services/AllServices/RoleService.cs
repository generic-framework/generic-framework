using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;

namespace Main.Server.Service.Services.AllServices
{
    public class RoleService : Service<Role>, IRoleService
    {
        private readonly IRoleService _roleService;

        public RoleService(IGenericRepository<Role> repository, IUnitOfWorks unitOfWorks, IRoleService roleService) : base(repository, unitOfWorks)
        {
            _roleService = roleService;
        }
    }
}
