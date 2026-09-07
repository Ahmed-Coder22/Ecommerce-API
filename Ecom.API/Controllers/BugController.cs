using Ecom.API.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("errors/{statuscode}")]
    [ApiController]
    public class BugController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error (int statuscode)
        {
            return new ObjectResult(new ResponseAPI(statuscode));
        }
    }
}
