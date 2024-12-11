using AutoMapper;
using generic_framework.Filters;
using Main.Server.Core.DTOs.UserDTOs.UpdateDTOs;
using generic_framework.Controller;
using Main.Server.Core.DTOs;

using Main.Server.Core.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.DTOs.TaskDTOs;
using Main.Server.Core.DTOs.TaskDTOs.UpdateDTOs;
using Main.Server.Service.Services;
using Main.Server.Core.Enums;
using Main.Server.Core.DTOs.ProjectDTOs;
using Main.Server.Core.Entities.ProjectEntities;
using Main.Server.Service.Services.AllServices;

namespace generic_framework.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : CustomBaseController
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly ITaskUserService _taskUserService;

        public TasksController(ITaskService taskService, IUserService userService, IMapper mapper, ITaskUserService taskUserService)
        {
            _taskService = taskService;
            _mapper = mapper;
            _userService = userService;
            _taskUserService = taskUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = _taskService.GetAll();

            var dtos = _mapper.Map<List<TaskDto>>(tasks).ToList();

            return CreateActionResult(CustomResponseDto<List<TaskDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<TaskEntity>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tasks = await _taskService.GetByIdAsync(id);

            var taskDtos = _mapper.Map<TaskDto>(tasks);

            return CreateActionResult(CustomResponseDto<TaskDto>.Success(200, taskDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<TaskEntity>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var task = await _taskService.GetByIdAsync(id);

            if (task.Files != null && task.Files.Any())
            {
                foreach (var file in task.Files)
                {
                    // Dosyayı fiziksel olarak sil
                    if (System.IO.File.Exists(file.FilePath))
                    {
                        System.IO.File.Delete(file.FilePath);
                    }
                }
            }

            task.UpdatedBy = userId;

            _taskService.ChangeStatus(task);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromForm] TaskDto taskDto, [FromForm] List<IFormFile> files)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<TaskEntity>(taskDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            if (Enum.IsDefined(typeof(PriorityTypes), processEntity.PriortyTypesId))
            {
                processEntity.PriorityTypes = (PriorityTypes)processEntity.PriortyTypesId;
            }
            else
            {
                throw new Exception("Invalid PriorityTypesId provided.");
            }

            if (Enum.IsDefined(typeof(SubjectTypes), processEntity.SubjectTypesId))
            {
                processEntity.SubjectTypes = (SubjectTypes)processEntity.SubjectTypesId;
            }
            else
            {
                throw new Exception("Invalid SubjectTypesId provided.");
            }
            var task = await _taskService.AddAsync(processEntity);

            // Dosyaları kaydet
            if (files != null && files.Any())
            {
                await SaveFilesToTask(files, task.Id);
            }

            var taskResponseDto = _mapper.Map<TaskDto>(task);

            return CreateActionResult(CustomResponseDto<TaskDto>.Success(201, taskResponseDto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] TaskUpdateDto updateDto, [FromForm] List<IFormFile> files)
        {
            int userId = GetUserFromToken();

            var currentTask = await _taskService.GetByIdAsync(updateDto.Id);

            currentTask.UpdatedBy = userId;
            currentTask.TaskTitle = updateDto.TaskTitle;
            currentTask.TaskDescription = updateDto.TaskDescription;
            currentTask.ProjectId = updateDto.ProjectId;
            currentTask.TaskStatuId = updateDto.TaskStatuId;
            currentTask.DeparmentId = updateDto.DeparmentId;
            currentTask.TaskUsers = updateDto.TaskUsers;
            currentTask.MainTaskId = updateDto.MainTaskId;
            currentTask.DevelopmentCompletionDate = updateDto.DevelopmentCompletionDate;
            currentTask.EndDate = updateDto.EndDate;
            currentTask.ProcessingDate = updateDto.ProcessingDate;
            currentTask.PriortyTypesId = updateDto.PriortyTypesId;
            currentTask.SubjectTypesId = updateDto.SubjectTypesId;
            if (Enum.IsDefined(typeof(PriorityTypes), currentTask.PriortyTypesId))
            {
                currentTask.PriorityTypes = (PriorityTypes)currentTask.PriortyTypesId;
            }
            else
            {
                throw new Exception("Invalid PriorityTypesId provided.");
            }

            if (Enum.IsDefined(typeof(SubjectTypes), currentTask.SubjectTypesId))
            {
                currentTask.SubjectTypes = (SubjectTypes)currentTask.SubjectTypesId;
            }
            else
            {
                throw new Exception("Invalid SubjectTypesId provided.");
            }

            _taskService.Update(currentTask);

            // Dosyaları kaydet
            if (files != null && files.Any())
            {
                await SaveFilesToTask(files, currentTask.Id);
            }

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        private async Task SaveFilesToTask(List<IFormFile> files, int taskId)
        {
            if (files == null || !files.Any()) return;

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Dosya meta bilgilerini kaydet
                await _taskService.SaveFileAsync(fileName, filePath, file.Length, taskId);
            }
        }

        [HttpPost("InserUserToTask")]
        public async Task<IActionResult> AddUserToTask([FromBody] TaskUserDto taskUserDto)
        {

            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<TaskUser>(taskUserDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;
            // Varlık doğrulama
            var user = await _userService.GetByIdAsync((int)taskUserDto.UserId);
            var task = await _taskService.GetByIdAsync((int)taskUserDto.TaskId);

            if (user == null || task == null)
            {
                return NotFound("Task or Project not found");
            }



            var taskUsers = await _taskUserService.AddAsync(processEntity);
            var taskResponseDto = _mapper.Map<TaskUserDto>(taskUsers);

            return CreateActionResult(CustomResponseDto<TaskUserDto>.Success(201, taskResponseDto));

        }
    }
}
