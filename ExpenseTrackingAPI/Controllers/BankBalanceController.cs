using ExpenseTrackingAPI.BRule.BusinessLayer.BankBalance;
using ExpenseTrackingAPI.Models.Model;
using ExpenseTrackingAPI.Services.BankBalance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBalanceController : ControllerBase
    {
        private readonly IBankBalanceService _bankBalanceService;

        public BankBalanceController(IBankBalanceService bankBalanceService)
        {
            _bankBalanceService = bankBalanceService;
        }

        [HttpGet("GetAllBankBalance/{UserID}")]
        public async Task<ActionResult<List<BankBalanceModel>>> GetAllBankBalance(Int32 UserID)
        {
            List<BankBalanceModel> bankBalanceModelList = new List<BankBalanceModel>();
            try
            {
                bankBalanceModelList = await _bankBalanceService.GetAllBankBalance(UserID);

                if (bankBalanceModelList == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(bankBalanceModelList);
        }

        [HttpGet("GetBankBalance/{BankID}/{UserID}")]
        public async Task<ActionResult<BankBalanceModel>> GetBankBalance(Int32 BankID, Int32 UserID)
        {
            BankBalanceModel bankBalanceModel = await _bankBalanceService.GetBankBalance(BankID, UserID);

            if (bankBalanceModel == null)
            {
                return NotFound();
            }

            return Ok(bankBalanceModel);
        }

        [HttpPost("AddBankBalance")]
        public async Task<ActionResult> AddBankBalance(BankBalanceModel bankBalanceModel)
        {
            try
            {
                await _bankBalanceService.AddBankBalance(bankBalanceModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpPut("UpdateBankBalance")]
        public async Task<ActionResult> UpdateBankBalance(BankBalanceModel bankBalanceModel)
        {
            try
            {
                await _bankBalanceService.UpdateBankBalance(bankBalanceModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("DeleteBankBalance/{BankID}/{UserID}")]
        public async Task<ActionResult> DeleteBankBalance(Int32 BankID, Int32 UserID)
        {
            try
            {
                await _bankBalanceService.DeleteBankBalance(BankID, UserID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }


}
