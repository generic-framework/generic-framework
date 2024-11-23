using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Repositories.IRepositories;

namespace Main.Server.DataAccess.Repositories.AllRepositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<Role> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
