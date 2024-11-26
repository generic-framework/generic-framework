using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.DTOs.UserDTOs;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Services.IServices
{
    public interface IUserService : IService<User>
    {
        User GetByEmail(string email);

        Task<Token> Login(UserLoginDto userLoginDto);
    }
}
