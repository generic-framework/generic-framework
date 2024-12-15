using AutoMapper;
using generic_framework.Filters;
using Main.Server.Core.DTOs;
using Main.Server.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Main.Server.Core.DTOs.DepartmentDTOs;
using Main.Server.Core.Entities.DepartmentEntities;

namespace generic_framework.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : CustomBaseController
    {
        private readonly IDepartmenService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmenService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = _departmentService.GetAll();
            var dtos = _mapper.Map<List<DepartmentDto>>(departments).ToList();

            return CreateActionResult(CustomResponseDto<List<DepartmentDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Department>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            var departmentDtos = _mapper.Map<DepartmentDto>(department);

            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(200, departmentDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Department>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var department = await _departmentService.GetByIdAsync(id);

            department.UpdatedBy = userId;

            _departmentService.ChangeStatus(department);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(DepartmentDto departmentDto)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<Department>(departmentDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            var department = await _departmentService.AddAsync(processEntity);

            var departmentResponseDto = _mapper.Map<DepartmentDto>(department);

            return CreateActionResult(CustomResponseDto<DepartmentDto>.Success(201, departmentResponseDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(DepartmentDto departmetnUpdateDto)
        {
            int userId = GetUserFromToken();

            var currentDepartment = await _departmentService.GetByIdAsync(departmetnUpdateDto.Id);

            currentDepartment.UpdatedBy = userId;
            currentDepartment.DepartmentName = currentDepartment.DepartmentName;
            currentDepartment.Description = currentDepartment.Description;
            currentDepartment.Users = currentDepartment.Users;

            _departmentService.Update(currentDepartment);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
