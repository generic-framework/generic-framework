using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Server.Core.Entities.ProductProp.ProductEntities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

    }
}
