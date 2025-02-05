using ExpenseTrackingAPI.BRule.BusinessLayer.Expense;
using ExpenseTrackingAPI.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenses _expenses;

        public ExpensesController(IExpenses expenses)
        {
            _expenses = expenses;
        }

        [HttpGet("GetExpensesWithUserID/{UserID}")]
        public async Task<ActionResult<List<ExpensesModel>>> GetExpensesWithUserID(Int32 UserID)
        {
            List<ExpensesModel> expensesModelList = new List<ExpensesModel>();
            try
            {
                expensesModelList = await _expenses.GetExpensesWithUserID(UserID);

                if (expensesModelList == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(expensesModelList);
        }

        [HttpPost("InsertExpenses")]
        public async Task<ActionResult> InsertExpenses(ExpensesModel expensesModel)
        {
            try
            {
                await _expenses.InsertExpenses(expensesModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpPut("UpdateExpense")]
        public async Task<ActionResult> UpdateExpense(ExpensesModel expensesModel)
        {
            try
            {
                await _expenses.UpdateExpense(expensesModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("DeleteExpense/{ExpensesID}")]
        public async Task<ActionResult> DeleteExpense(Int32 ExpensesID)
        {
            try
            {
                await _expenses.DeleteExpense(ExpensesID);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
