using BudgetApp.Dtos.ExpenseUtils;
using BudgetApp.Models;
using BudgetApp.Repositories.ExpenseRepository;
using Mapster;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BudgetApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        // GET: api/<ExpenseController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_expenseRepository.GetAll());
        }

        // GET api/<ExpenseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var res = _expenseRepository.GetById(id);
                if (res.Result == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ExpenseController>
        [HttpPost]
        public IActionResult Post([FromBody] ExpenseCreateRequest value)
        {
            try
            {
                Expense expense = value.Adapt<Expense>();
                var res = _expenseRepository.Add(expense);
                if (res.Result)
                {
                    return Ok("Added successfully");
                }
                return BadRequest("Failed to add expense");
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ExpenseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ExpenseRequest value)
        {
            try
            {
                Expense expense = value.Adapt<Expense>();
                expense.Id = id;
                var result = _expenseRepository.Update(expense);
                if (result.Result)
                {
                    return Ok("Updated successfully");
                }
                return BadRequest("Failed to update");
            }
            catch(Exception e) 
            {
                return BadRequest(e);
            }
        }

        // DELETE api/<ExpenseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var result = _expenseRepository.Delete(id);
                if (result.Result)
                {
                    return Ok("Deleted Successfully");
                }
                return BadRequest("Failed to delete");
            }
            catch(Exception ex)
            {
                return BadRequest($"Could not delete {ex.Message}");
            }
        }
    }
}
