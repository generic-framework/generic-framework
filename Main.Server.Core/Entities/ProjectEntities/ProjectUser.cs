using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.UserEntities;

namespace Main.Server.Core.Entities.ProjectEntities
{
    public class ProjectUser : BaseEntity
    {
        public int? UserId { get; set; }
        public int? ProjectId { get; set; }

        public User? User { get; set; }
        public Project? Project { get; set; }
    }
}
