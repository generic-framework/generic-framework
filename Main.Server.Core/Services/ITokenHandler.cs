using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Services
{
    public interface ITokenHandler
    {
        Token CreateToken(User user, List<Role> roles);
        string CreateRefreshToken();
        IEnumerable<Claim> SetClaims(User user, List<Role> roles);
    }
}
