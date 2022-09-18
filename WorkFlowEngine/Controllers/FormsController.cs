using Database.Models.Interfaces;
using Database.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WorkFlowEngine.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FormsController : Controller
    {
        #region
        private readonly IUnitOfWork _iUnitOfWork;
        public FormsController(IUnitOfWork _iUnitOfWork)
        {
            this._iUnitOfWork = _iUnitOfWork;
        }
        #endregion

        [HttpPost("PostForm")]
        public async Task<ActionResult> PostForm()
        {
            return Ok();
        }

        [HttpGet("GetForms")]
        public async Task<ActionResult> GetForms()
        {

            return Ok();
        }
    }
}
