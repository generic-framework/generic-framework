using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.UserEntities;
using Main.Server.Core.Services;
using Main.Server.Service.Extentions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Main.Server.Service.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32]; 
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        public Token CreateToken(User user, List<Role> roles)
        {
            Token token = new Token();
            SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddDays(7);

            var claims = SetClaims(user, roles);

            JwtSecurityToken tokenSecurityToken = new JwtSecurityToken(
            issuer: _configuration["Token:Issuer"],
            audience: _configuration["Token:Audience"],
            claims: claims, // Claims burada token'a ekleniyor
            expires: token.Expiration,
            notBefore: DateTime.Now,
            signingCredentials: signingCredentials
        );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            token.AccessToken = jwtSecurityTokenHandler.WriteToken(tokenSecurityToken);

            token.RefreshToken = CreateRefreshToken();

            return token;
        }

        public IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            Claim claim = new("sub", user.Id.ToString());
            List<Claim> claims = new List<Claim>();

            claims.Add(claim);
            claims.AddName(user.Name);
            claims.AddSurname(user.Surname);
            claims.AddRoles(roles.Select(p => p.RoleName).ToArray());

            return claims;  

        }
    }
}
