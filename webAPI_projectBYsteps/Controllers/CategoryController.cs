using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service;

namespace webAPI_projectBYsteps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await _categoryService.Get();

            if (categories != null)
            {
                List<categoryDTO> categoriesDTO = _mapper.Map<List<Category>, List<categoryDTO>>(categories);
                return Ok(categoriesDTO);
            }

            return NoContent();
        }
    }
}
