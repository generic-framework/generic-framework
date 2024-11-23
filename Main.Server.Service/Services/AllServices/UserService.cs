using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;
using Main.Server.DataAccess.Repositories.AllRepositories;

namespace Main.Server.Service.Services.AllServices
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IGenericRepository<User> repository, IUnitOfWorks unitOfWorks, IUserRepository userRepository)
            : base(repository, unitOfWorks)
        {
            _userRepository = userRepository;
        }
    }
}
