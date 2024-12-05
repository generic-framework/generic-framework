using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.TaskEntities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;
using Main.Server.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Main.Server.Service.Services.AllServices
{
    public class TaskService : Service<TaskEntity>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly AppDbContext _dbContext;

        public TaskService(IGenericRepository<TaskEntity> repository, ITaskRepository taskRepository,
            IUnitOfWorks unitOfWorks, AppDbContext dbContext) : base(repository, unitOfWorks)
        {
            _taskRepository = taskRepository;
            _dbContext = dbContext;

        }

        public async Task<TaskFile> SaveFileAsync(string fileName, string filePath, long fileSize, int taskId)
        {
            var file = new TaskFile
            {
                FileName = fileName,
                FilePath = filePath,
                FileSize = fileSize,
                TaskId = taskId,
                CreatedDate = DateTime.UtcNow
            };

            _dbContext.TaskFiles.Add(file);
            await _dbContext.SaveChangesAsync();
            return file;
        }
    }
}
