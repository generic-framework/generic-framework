using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Repositories.IRepositories;

namespace Main.Server.DataAccess.Repositories.AllRepositories
{
    public class TaskStatusRepository : GenericRepository<TaskStatusEntity>, ITaskStatusRepository
    {
        private readonly AppDbContext _context;

        public TaskStatusRepository(AppDbContext context) : base(context)
        {
            _context = context;

        }
    }
}
