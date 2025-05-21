using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oxu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("{Id}")]
    }
}
