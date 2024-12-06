using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;

namespace Main.Server.Service.Services.AllServices
{
    public class TaskStatusService : Service<TaskStatusEntity>, ITaskStatusService
    {
        private readonly ITaskStatusRepository _taskStatusRepository;
        public TaskStatusService(IGenericRepository<TaskStatusEntity> repository,
            IUnitOfWorks unitOfWorks, ITaskStatusRepository taskStatusRepository) 
            : base(repository, unitOfWorks)
        {
            _taskStatusRepository = taskStatusRepository;
        }
    }
}
