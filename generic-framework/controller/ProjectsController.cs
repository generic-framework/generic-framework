using AutoMapper;
using generic_framework.Filters;
using Main.Server.Core.DTOs;
using Main.Server.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Main.Server.Core.DTOs.ProjectDTOs;
using Main.Server.Core.Entities.ProjectEntities;

namespace generic_framework.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : CustomBaseController
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = _projectService.GetAll();
            var dtos = _mapper.Map<List<ProjectDto>>(projects).ToList();

            return CreateActionResult(CustomResponseDto<List<ProjectDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Project>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetByIdAsync(id);

            var projectDtos = _mapper.Map<ProjectDto>(project);

            return CreateActionResult(CustomResponseDto<ProjectDto>.Success(200, projectDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Project>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var project = await _projectService.GetByIdAsync(id);

            project.UpdatedBy = userId;

            _projectService.ChangeStatus(project);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(ProjectDto projectDto)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<Project>(projectDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            var project = await _projectService.AddAsync(processEntity);

            var projectResponseDto = _mapper.Map<ProjectDto>(project);

            return CreateActionResult(CustomResponseDto<ProjectDto>.Success(201, projectResponseDto));

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProjectDto projectDto)
        {
            int userId = GetUserFromToken();

            var currentProject = await _projectService.GetByIdAsync(projectDto.Id);

            currentProject.UpdatedBy = userId;
            currentProject.ProjectName = projectDto.ProjectName;
            currentProject.ProjectTypeId = projectDto.ProjectTypeId;

            _projectService.Update(currentProject);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
