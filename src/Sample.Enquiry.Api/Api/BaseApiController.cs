using Microsoft.AspNetCore.Mvc;

namespace Sample.Enquiry.Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
