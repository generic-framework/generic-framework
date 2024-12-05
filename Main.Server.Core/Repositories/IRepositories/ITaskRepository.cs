using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.Repositories.IRepositories
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
    }
}
