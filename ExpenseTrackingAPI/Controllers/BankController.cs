using ExpenseTrackingAPI.Models.Model;
using ExpenseTrackingAPI.Services.Bank;
using ExpenseTrackingAPI.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("GetAllBank")]
        public async Task<ActionResult<List<BankModel>>> GetAllBank()
        {
            List<BankModel> bankModelList = new List<BankModel>();
            try
            {
                bankModelList = await _bankService.GetAllBank();

                if (bankModelList[0].BankId == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(bankModelList);
        }

        [HttpGet("GetBank/{BankID}")]
        public async Task<ActionResult<BankModel>> GetBank(Int32 BankID)
        {
            BankModel bankModel = new BankModel();
            try
            {
                bankModel = await _bankService.GetBank(BankID);

                if (bankModel.BankId == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(bankModel);
        }

        [HttpPost("AddBank")]
        public async Task<ActionResult> AddBank(BankModel bankModel)
        {           

            try
            {
               await _bankService.AddBank(bankModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpPut("UpdateBank")]
        public async Task<ActionResult> UpdateBank(BankModel bankModel)
        {

            try
            {
                await _bankService.UpdateBank(bankModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("DeleteBank/{BankID}")]
        public async Task<ActionResult> DeleteBank(Int32 BankID)
        {
            try
            {
                await _bankService.DeleteBank(BankID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
