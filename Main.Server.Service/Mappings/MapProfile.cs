using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Main.Server.Core.DTOs.ProductDTOs;
using Main.Server.Core.DTOs.RoleDTOs;
using Main.Server.Core.DTOs.UserDTOs;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Service.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
              CreateMap<User,UserDto>().ReverseMap();  
              CreateMap<Role,RoleDto>().ReverseMap();  
              CreateMap<Product,ProductDto>().ReverseMap();
        }
    }
}
