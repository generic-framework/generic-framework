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
        private readonly IRoleRepository _roleRepository;

        public RoleService(IGenericRepository<Role> repository,
            IUnitOfWorks unitOfWorks, IRoleRepository roleRepository) 
            : base(repository, unitOfWorks)
        {
            _roleRepository = roleRepository;
        }
    }
}
