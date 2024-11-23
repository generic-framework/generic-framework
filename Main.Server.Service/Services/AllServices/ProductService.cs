using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Repositories;
using Main.Server.Core.Services.IServices;
using Main.Server.Core.UnitOfWorks;

namespace Main.Server.Service.Services.AllServices
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductService _productService;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWorks unitOfWorks, IProductService productService) : base(repository, unitOfWorks)
        {
            _productService = productService;
        }
    }
}
