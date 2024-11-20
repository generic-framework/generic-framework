﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public bool Status { get; set; }

    }
}
