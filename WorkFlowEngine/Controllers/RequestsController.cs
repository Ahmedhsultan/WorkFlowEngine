#region Library
using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WorkFlowEngine.Models.DTOs.Tasks;
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
        public async Task<ActionResult<IEnumerable<Requests>>> GetAvilableRequests([FromHeader]string userName)
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

        [HttpPost("StartRequest")]
        public async Task<ActionResult<bool>> StartRequest(ClientCreateTaskDTO clientCreateTaskDTO)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(clientCreateTaskDTO.userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(clientCreateTaskDTO.userName);
                Processes breviousProcesses = await _iUnitOfWork.processRepository.GetById(new Guid(clientCreateTaskDTO.PreviusProcessGUID));
                Processes newProcesses = await _iUnitOfWork.processRepository.GetById(breviousProcesses.nextProcessIdNo1);
                Tasks task = new Tasks()
                {
                    taskName = "Task",
                    createOn = DateTime.Now,
                    outhUser = newProcesses.outhUser,
                    runningRequests = new RunningRequests()
                    {
                        requestName = newProcesses.digram.digramName,
                        assigneeUser = user,
                        createOn = DateTime.Now,
                        status = Database.Models.Enums.Status.Active,
                    },
                    process = newProcesses
                };
                //Save all changes
                await _iUnitOfWork.tasksRepository.addNewTask(task);
                await _iUnitOfWork.Complete();

                return Ok();
            }
            return BadRequest("Invalid UserName");
        }

        [HttpGet("GetAvilableRunningRequests")]
        public async Task<ActionResult<IEnumerable<RunningRequests>>> GetAvilableRunningRequests([FromHeader] string userName)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(userName);
                if (await _iUnitOfWork.runningRequestsRepository.IsExistRunningRequests(user))
                {
                    IEnumerable<RunningRequests> runningRequests = await _iUnitOfWork.runningRequestsRepository.GetByUser(user);

                    return Ok(runningRequests);
                }
                return BadRequest("Invalid RunningRequests");
            }
            return BadRequest("Invalid UserName");
        }
    }
}
