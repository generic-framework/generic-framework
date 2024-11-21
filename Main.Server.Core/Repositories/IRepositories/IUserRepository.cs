using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Repositories.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAllUser();

        List<User> GetFilteredUser(int Id, string name, string surname, int role);
    }
}
