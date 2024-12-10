using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Entities.DepartmentEntities
{
    public class Department :  BaseEntity
    {
        public string DepartmentName { get; set; }

        public string Description { get; set; }

        public ICollection<User>? Users { get; set; }

    }
}
