using ExpenseTrackingAPI.BRule.BusinessLayer.CashBalace;
using ExpenseTrackingAPI.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashBalaceController : ControllerBase
    {
        private readonly ICashBalace _cashBalace;

        public CashBalaceController(ICashBalace cashBalace)
        {
            _cashBalace = cashBalace;
        }

        [HttpGet("CashBalance/{UserID}")]
        public async Task<ActionResult<CashBalaceModel>> CashBalance(Int32 UserID)
        {
            CashBalaceModel cashBalaceModel = await _cashBalace.GetCashBalanceWithUserID(UserID);

            if (cashBalaceModel == null)
            {
                return NotFound();
            }

            return Ok(cashBalaceModel);
        }

        [HttpPost("CashBalance")]
        public async Task<ActionResult> CashBalance(CashBalaceModel cashBalaceModel)
        {
            await _cashBalace.InsertCashBalance(cashBalaceModel);

            return Ok();
        }

        [HttpPut("UpdateCashBalance")]
        public async Task<ActionResult> UpdateCashBalance(CashBalaceModel cashBalaceModel)
        {
            await _cashBalace.UpdateCashBalance(cashBalaceModel);

            return Ok();
        }

        [HttpDelete("DeleteCashBalance/{UserID}")]
        public async Task<ActionResult> DeleteCashBalance(Int32 UserID)
        {
            await _cashBalace.DeleteCashBalance(UserID);


            return Ok();
        }
    }
}
