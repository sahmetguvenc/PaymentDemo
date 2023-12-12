namespace PaymentDemo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<T> : ControllerBase
    {
        protected readonly ISender Sender;
        protected BaseController(ISender sender)
        {
            Sender = sender;
        }

    }
}
