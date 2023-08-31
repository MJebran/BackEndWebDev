using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ch2FirstWebAPI.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult Error()
        {
            return Problem();
        }

        [Route("/error")]
        [HttpGet]
        public IActionResult Test() { throw new Exception("TEST"); }
    }
}
