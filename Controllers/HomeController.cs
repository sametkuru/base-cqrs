using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Udemy.Cqrs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Created("",null);
        }
    }
}