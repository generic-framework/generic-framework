using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.Repositories.IRepositories;

namespace Main.Server.DataAccess.Repositories.AllRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public List<User> GetFilteredUser(int Id, string name, string surname, int role)
        {
            throw new NotImplementedException();
        }
    }
}
