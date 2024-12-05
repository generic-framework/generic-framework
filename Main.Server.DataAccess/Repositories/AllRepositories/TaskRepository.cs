using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Repositories.IRepositories;

namespace Main.Server.DataAccess.Repositories.AllRepositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) : base(context)
        {
        }
    }
}
