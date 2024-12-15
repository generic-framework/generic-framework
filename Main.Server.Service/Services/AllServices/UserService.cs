using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.DTOs.UserDTOs;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Services;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;
using Main.Server.Service.Hashing;

namespace Main.Server.Service.Services.AllServices
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenHandler _tokenHandler;
        public UserService(IGenericRepository<User> repository, 
            IUnitOfWorks unitOfWorks,
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            ITokenHandler tokenHandler)
            : base(repository, unitOfWorks)
        {
             _tokenHandler = tokenHandler;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public User GetByEmail(string email)
        {
            User user = _userRepository.Where(x => x.Email == email).FirstOrDefault();

            return user ?? user;
        }

        public async Task<Token> Login(UserLoginDto userLoginDto)
        {
            Token token = new Token();

            var user = GetByEmail(userLoginDto.Email);

            if (user == null) 
            {
                return null;
            }
            var result = false; 
             result = HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSalt);
                 
            List<Role> roles = new List<Role>();

            var role = await _roleRepository.GetByIdAsync(user.RoleId);

            roles.Add(role);

            if (result)
            {
                token = _tokenHandler.CreateToken(user, roles);
                return token;
            }
            return null;
        }
    }
}
