#region Library
using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
#endregion

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/Requests")]
    public class RequestsController : Controller
    {
        #region Debendancy injection
        private readonly IUnitOfWork _iUnitOfWork;
        public RequestsController(IUnitOfWork _iUnitOfWork)
        {
            this._iUnitOfWork = _iUnitOfWork;
        }
        #endregion


        [HttpGet("GetAvilableRequests")]
        public async Task<ActionResult<IEnumerable<Requests>>> GetAvilableRequests(string userName)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(userName);
                if (await _iUnitOfWork.requestsRepository.IsExistRequest(user))
                {
                    IEnumerable<Requests> requests = await _iUnitOfWork.requestsRepository.GetByUser(user);

                    return Ok(requests);
                }
                return BadRequest("Invalid Requests");
            }
            return BadRequest("Invalid UserName");
        }
    }
}
