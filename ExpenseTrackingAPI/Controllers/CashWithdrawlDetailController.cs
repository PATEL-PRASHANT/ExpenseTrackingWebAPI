using ExpenseTrackingAPI.BRule.BusinessLayer.CashWithdrawlDetail;
using ExpenseTrackingAPI.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashWithdrawlDetailController : ControllerBase
    {
        private readonly ICashWithdrawlDetail _cashWithdrawlDetail;

        public CashWithdrawlDetailController(ICashWithdrawlDetail cashWithdrawlDetail)
        {
            _cashWithdrawlDetail = cashWithdrawlDetail;
        }

        [HttpGet("CashWithdrawlDetaile/{UserID}")]
        public async Task<ActionResult<List<CashWithdrawlDetailModel>>> CashWithdrawlDetaile(Int32 UserID)
        {
            List<CashWithdrawlDetailModel> cashWithdrawlDetailModelList = new List<CashWithdrawlDetailModel>();
            try
            {
                cashWithdrawlDetailModelList = await _cashWithdrawlDetail.GetCashWithdrawlDetaileWithUserID(UserID);

                if (cashWithdrawlDetailModelList == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(cashWithdrawlDetailModelList);
        }

        [HttpPost("CashWithdrawlDetaile")]
        public async Task<ActionResult> CashWithdrawlDetaile(CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            try
            {
                await _cashWithdrawlDetail.InsertCashWithdrawlDetaile(cashWithdrawlDetailModel);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

        [HttpPut("UpdateCashWithdrawlDetaile")]
        public async Task<ActionResult> UpdateCashWithdrawlDetaile(CashWithdrawlDetailModel cashWithdrawlDetailModel)
        {
            try
            {
                await _cashWithdrawlDetail.UpdateCashWithdrawlDetaile(cashWithdrawlDetailModel);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("DeleteCashWithdrawlDetaile/{UserID},{CashWithdrawlDetailID}")]
        public async Task<ActionResult> DeleteCashWithdrawlDetaile(Int32 UserID, Int32 CashWithdrawlDetailID)
        {
            try
            {
                await _cashWithdrawlDetail.DeleteCashWithdrawlDetaile(UserID, CashWithdrawlDetailID);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
