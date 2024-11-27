using AutoMapper;
using generic_framework.Controller;
using generic_framework.Filters;
using Main.Server.Core.DTOs;
using Main.Server.Core.DTOs.ProductDTOs;
using Main.Server.Core.DTOs.ProductDTOs.UpdateDTOs;
using Main.Server.Core.Entities.ProductEntities;
using Main.Server.Core.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace generic_framework.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = _productService.GetAll();
            var dtos = _mapper.Map<List<ProductDto>>(products).ToList();

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, dtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            var productDtos = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("[action]")]
        public async Task<IActionResult> Remove(int id)
        {
            int userId = GetUserFromToken();

            var product = await _productService.GetByIdAsync(id);

            product.UpdatedBy = userId;

            _productService.ChangeStatus(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(ProductDto productDto)
        {
            int userId = GetUserFromToken();

            var processEntity = _mapper.Map<Product>(productDto);

            processEntity.UpdatedBy = userId;
            processEntity.CreatedBy = userId;

            var product = await _productService.AddAsync(processEntity);

            var productResponseDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productDto));

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            int userId = GetUserFromToken();

            var currentProduct = await _productService.GetByIdAsync(productUpdateDto.Id);

            currentProduct.UpdatedBy = userId;
            currentProduct.ProductName = productUpdateDto.ProductName;
            currentProduct.ProductDescription = productUpdateDto.ProductDescription;

            _productService.Update(currentProduct);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }
}
