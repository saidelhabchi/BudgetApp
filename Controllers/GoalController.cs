using BudgetApp.Dtos.GoalUtils;
using BudgetApp.Models;
using BudgetApp.Repositories.CategoryRepository;
using BudgetApp.Repositories.GoalRepository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalRepository _goalRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GoalController(IGoalRepository goalRepository, ICategoryRepository categoryRepository)
        {
            _goalRepository = goalRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: api/<GoalController>
        [HttpGet]
        public IEnumerable<GoalResponse> Get()
        {
            List<GoalResponse> response = _goalRepository.GetAll().Select(g =>
            {
                var gr = g.Adapt<GoalResponse>();
                gr.Category = _categoryRepository.GetById(g.CategoryId).Result;
                return gr;
            }).ToList();
            return response;
        }

        // GET api/<GoalController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var res = _goalRepository.GetById(id);
                return Ok(res);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<GoalController>
        [HttpPost]
        public IActionResult Post([FromBody] GoalAddRequest value)
        {
            try
            {
                Goal goal = value.Adapt<Goal>();
                goal.UpdatedAt = goal.CreatedAt = DateTime.Now;
                _goalRepository.Add(goal);
                return Ok(goal);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<GoalController>/5
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] GoalRequest value)
        {
            try
            {
                Goal goal = value.Adapt<Goal>();
                goal.Id = id;
                Task<bool> result = _goalRepository.Update(goal);
                if (result.Result)
                {
                    return Ok("Updated successfully");
                }
                return BadRequest("Update failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GoalController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _goalRepository.Delete(id);
                if (result.Result)
                {
                    return Ok("Deleted successfully");
                }
                else
                {
                    return BadRequest("Delate failed");
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not delete {id}");
            }
        }
    }
}
