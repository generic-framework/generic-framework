using AutoMapper;
using generic_framework.Filters;
using Main.Server.Core.DTOs;
using Main.Server.Core.Services.IServices;
using Main.Server.Service.Services.AllServices;
using Microsoft.AspNetCore.Mvc;
using Main.Server.Core.DTOs.RoleDTOs;
using Main.Server.Core.Entities.RoleEntities;
using Main.Server.Core.DTOs.RoleDTOs.UpdateDTOs;

namespace generic_framework.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : CustomBaseController
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = _roleService.GetAll();
            var dtos = _mapper.Map<List<RoleDto>>(roles).ToList();

            return CreateActionResult(CustomResponseDto<List<RoleDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Role>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);

            var roleDtos = _mapper.Map<RoleDto>(role);

            return CreateActionResult(CustomResponseDto<RoleDto>.Success(200, roleDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Role>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var role = await _roleService.GetByIdAsync(id);

            role.UpdatedBy = userId;

            _roleService.ChangeStatus(role);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(RoleDto roleDto)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<Role>(roleDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            var role = await _roleService.AddAsync(processEntity);

            var userResponseDto = _mapper.Map<RoleDto>(role);

            return CreateActionResult(CustomResponseDto<RoleDto>.Success(201, userResponseDto));

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(RoleUpdateDto updateDto)
        {
            int userId = GetUserFromToken();

            var currentRole = await _roleService.GetByIdAsync(updateDto.Id);

            currentRole.UpdatedBy = userId;
            currentRole.RoleName = updateDto.RoleName;

            _roleService.Update(currentRole);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
