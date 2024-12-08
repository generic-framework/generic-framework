using generic_framework.Filters;
using Main.Server.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.DTOs.TaskDTOs;
using Main.Server.Core.Entities.TaskEntities;

namespace generic_framework.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksStatusController : CustomBaseController
    {
        private readonly ITaskStatusService _taskStatusService;
        private readonly IMapper _mapper;


        public TasksStatusController(ITaskStatusService taskStatusService, IMapper mapper)
        {
            _taskStatusService = taskStatusService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var status = _taskStatusService.GetAll();
            var dtos = _mapper.Map<List<TaskStatusDto>>(status).ToList();

            return CreateActionResult(CustomResponseDto<List<TaskStatusDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<TaskStatusEntity>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _taskStatusService.GetByIdAsync(id);

            var statusDtos = _mapper.Map<TaskStatusDto>(status);

            return CreateActionResult(CustomResponseDto<TaskStatusDto>.Success(200, statusDtos));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(TaskStatusDto statusDto)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<TaskStatusEntity>(statusDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            var status = await _taskStatusService.AddAsync(processEntity);

            var taskStatusResponseDto = _mapper.Map<TaskStatusDto>(status);

            return CreateActionResult(CustomResponseDto<TaskStatusDto>.Success(201, taskStatusResponseDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(TaskStatusDto statusDto)
        {
            int userId = GetUserFromToken();

            var currentStatus = await _taskStatusService.GetByIdAsync(statusDto.Id);

            currentStatus.UpdatedBy = userId;
            currentStatus.StatusName = statusDto.StatusName;
            currentStatus.StatusPosition = statusDto.StatusPosition;

            _taskStatusService.Update(currentStatus);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        [ServiceFilter(typeof(NotFoundFilter<TaskStatusEntity>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var status = await _taskStatusService.GetByIdAsync(id);

            status.UpdatedBy = userId;

            _taskStatusService.ChangeStatus(status);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
