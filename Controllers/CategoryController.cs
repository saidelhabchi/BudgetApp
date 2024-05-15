using BudgetApp.Dtos.CategoryUtils;
using BudgetApp.Models;
using BudgetApp.Repositories.CategoryRepository;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var res = _categoryRepository.GetAll();
            if(res.Any())
            {
                IEnumerable<CategoryResponse> categories = res.Select(c => c.Adapt<CategoryResponse>());
                return Ok(categories);
            }
            return StatusCode(200,res);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var res = _categoryRepository.GetById(id);
                if (res != null)
                {
                    return Ok(res);
                }
                return NotFound("This Category doesn't exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryRequest value)
        {
            var cat = value.Adapt<Category>();
            var res = await _categoryRepository.Add(cat);
            if (res)
            {
                return Ok("Added successfully");
            }
            return BadRequest("Failed adding category");
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CategoryRequest value)
        {
            var cat = value.Adapt<Category>();
            cat.Id = id;
            var res = await _categoryRepository.Update(cat);

            if (res == true)
            {
                return Ok("Updated successfully");
            }
            else
            {
                return BadRequest("Failed updating this category");
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _categoryRepository.Delete(id);

            if (res)
            {
                return Ok("Deleted Successfully");
            }
            return BadRequest("Failed deleting");
        }
    }
}
