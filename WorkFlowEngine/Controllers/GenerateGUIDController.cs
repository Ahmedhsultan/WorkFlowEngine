using Microsoft.AspNetCore.Mvc;

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/GenerateGUID")]
    public class GenerateGUIDController : Controller
    {
        [HttpGet("{listOfGUIDLength:int}")]
        public ActionResult<List<string>> GenerateGUID(int listOfGUIDLength)
        {
            List<string> guids = new List<string>();
            for (int i = 0; i < listOfGUIDLength; i++)
                guids.Add(Guid.NewGuid().ToString());
            return guids;
        }
    }
}
