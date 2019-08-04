using Microsoft.AspNetCore.Mvc;

namespace Sample.Enquiry.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
