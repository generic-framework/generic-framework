using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities;
using Main.Server.Core.Entities.TaskEntities;

namespace Main.Server.Core.Services.IServices
{
    public interface ITaskService : IService<TaskEntity>
    {
        Task<TaskFile> SaveFileAsync(string fileName, string filePath, long fileSize, int taskId);
    }
}
