using PaymentDemo.Application.Features.Banks.Commands;
using PaymentDemo.Application.Features.Banks.Queries;

namespace PaymentDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : BaseController<BankController>
    {
        public BankController(ISender sender) : base(sender)
        {
        }

        [HttpGet("id/")]
        public async Task<IActionResult> GetById(int id)
        {
            var bank = await Sender.Send(new GetBankByIdQuery(id));
            return Ok(bank);
        }

        [HttpGet("name/")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = await Sender.Send(new GetBankByNameQuery(name));
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBankCommand command)
        {
            return Ok(await Sender.Send(command));
        }

    }
}
