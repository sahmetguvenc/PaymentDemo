using PaymentDemo.Application.Features.Report.Queries;

namespace PaymentDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController<ReportController>
    {
        public ReportController(ISender sender) : base(sender)
        {
            
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport([FromQuery] ReportQuery reportQuery)
        {
           var result = await Sender.Send(new ReportQuery(reportQuery.BankId,
                                                          reportQuery.Status,
                                                          reportQuery.OrderReference,
                                                          reportQuery.StartDate,
                                                          reportQuery.EndDate));
           return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
 
        }

    }
}
