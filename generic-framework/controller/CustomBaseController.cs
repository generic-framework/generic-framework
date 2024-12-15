﻿using System.IdentityModel.Tokens.Jwt;
using Main.Server.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_framework.Controller
{
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204) 
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            }
            return new ObjectResult(response) { StatusCode = response.StatusCode};
        }
        [NonAction]
        public int GetUserFromToken()
        {
            string requestHeader = Request.Headers["Authorization"];
            string jwt = requestHeader?.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadToken(jwt) as JwtSecurityToken;
            string userId = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "sub")?.Value;
            int id = Int32.Parse(userId);
            return id == 0 ? 0 : id;

        }
    }
}
