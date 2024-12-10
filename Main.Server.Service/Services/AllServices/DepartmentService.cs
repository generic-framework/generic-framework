using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.DepartmentEntities;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Repositories.IRepositories;
using Main.Server.Core.Repositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;

namespace Main.Server.Service.Services.AllServices
{
    public class DepartmentService : Service<Department>, IDepartmenService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IGenericRepository<Department> repository, IUnitOfWorks unitOfWorks, IDepartmentRepository departmentRepository)
            : base(repository, unitOfWorks)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
