using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Core.Repositories.IRepositories;

namespace Main.Server.DataAccess.Repositories.AllRepositories
{
    public class ProjectUserRepository : GenericRepository<ProjectUser>, IProjectUserRepository
    {
        private readonly AppDbContext _context;

        public ProjectUserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
