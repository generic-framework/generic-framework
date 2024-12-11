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
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Service.Services.AllServices
{
    public class TaskUserService : Service<TaskUser>, ITaskUserService
    {
        private readonly ITaskUserRepository _taskRepository;
        public TaskUserService(IGenericRepository<TaskUser> repository,
            ITaskUserRepository taskRepository,
            IUnitOfWorks unitOfWorks) :
            base(repository, unitOfWorks)
        {
            _taskRepository = taskRepository;
        }
    }
}
