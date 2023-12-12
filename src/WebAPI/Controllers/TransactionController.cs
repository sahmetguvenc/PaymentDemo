using PaymentDemo.Application.Features.Transaction.Commands;

namespace PaymentDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : BaseController<TransactionController>
    {
        public TransactionController(ISender sender) : base(sender)
        {
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromBody] PayTransactionCommand request)
        {
            try
            {
                return Ok(await Sender.Send(request));
             
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Cancel")]
        public async Task<IActionResult> Cancel([FromBody] CancelTransactionCommand request)
        {
            try
            {
                return Ok(await Sender.Send(request));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Refund")]
        public async Task<IActionResult> Refund([FromBody] RefundTransactionCommand request)
        {
            try
            {
                return Ok(await Sender.Send(request));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
