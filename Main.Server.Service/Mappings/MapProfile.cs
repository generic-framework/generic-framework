using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Main.Server.Core.DTOs;
using Main.Server.Core.DTOs.ProductDTOs;
using Main.Server.Core.DTOs.ProjectDTOs;
using Main.Server.Core.DTOs.RoleDTOs;
using Main.Server.Core.DTOs.TaskDTOs;
using Main.Server.Core.DTOs.UserDTOs;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.Entities.TaskEntities;
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
              CreateMap<TaskEntity, TaskDto>().ReverseMap();
              CreateMap<TaskFile, FileDto>().ReverseMap();
              CreateMap<TaskStatusEntity, TaskStatusDto>().ReverseMap();
              CreateMap<Project, ProjectDto>().ReverseMap();
        }
    }
}
