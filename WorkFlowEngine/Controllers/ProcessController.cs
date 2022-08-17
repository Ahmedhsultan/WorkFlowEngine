using Microsoft.AspNetCore.Mvc;

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProcessController : Controller
    {
        [HttpGet("RunProcess")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
