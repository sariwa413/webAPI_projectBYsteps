using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace webAPI_projectBYsteps.Controllers
{  
    [Route("api/[controller]")]
        [ApiController]
    public class ProductController : ControllerBase
    {
      
        IProductService _productService;
        IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public async Task<ActionResult<List<productDTO>>> Get(int? minPrice, int? maxPrice, [FromQuery] List<int>? categoryIds, String? description, String? sortBy)
        {
            List<Product> products = await _productService.Get(minPrice, maxPrice, categoryIds, description, sortBy);
            if (products != null)
            {
                List<productDTO> productsDTO = _mapper.Map<List<Product>, List<productDTO>>(products);
                return Ok(productsDTO);
            }
            return NoContent();
        }
    } 
}

