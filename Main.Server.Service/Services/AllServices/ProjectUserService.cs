using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Repositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;

namespace Main.Server.Service.Services.AllServices
{
    internal class ProjectUserService : Service<ProjectUser>, IProjectUserService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectUserService(IGenericRepository<ProjectUser> repository,
            IProjectRepository projectRepository,
            IUnitOfWorks unitOfWorks) :
            base(repository, unitOfWorks)
        {
            _projectRepository = projectRepository;
        }
    }
}
