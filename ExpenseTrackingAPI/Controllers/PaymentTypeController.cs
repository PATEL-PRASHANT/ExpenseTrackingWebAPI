using ExpenseTrackingAPI.BRule.BusinessLayer.PaymentType;
using ExpenseTrackingAPI.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentType _paymentType;

        public PaymentTypeController(IPaymentType paymentType)
        {
            _paymentType = paymentType;
        }

        [HttpGet("PaymentType")]
        public async Task<ActionResult<List<PaymentTypeModel>>> PaymentType()
        {
            List<PaymentTypeModel> paymentTypeModelList = new List<PaymentTypeModel>();
            try
            {
                paymentTypeModelList = await _paymentType.GetPaymentTypes();

                if (paymentTypeModelList == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(paymentTypeModelList);
        }

        [HttpPost("PaymentType")]
        public async Task<ActionResult> PaymentType(PaymentTypeModel paymentTypeModel)
        {
            try
            {
                await _paymentType.InsertPaymentTypes(paymentTypeModel);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }


    }
}
