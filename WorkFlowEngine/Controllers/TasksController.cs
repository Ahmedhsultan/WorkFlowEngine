#region Library
using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WorkFlowEngine.Models.DTOs.Tasks;
#endregion

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/Tasks")]
    public class TasksController : Controller
    {
        #region Debendancy injection
        private readonly IUnitOfWork _iUnitOfWork;
        public TasksController(IUnitOfWork _iUnitOfWork)
        {
            this._iUnitOfWork = _iUnitOfWork;
        }
        #endregion

        
        [HttpGet("GetAvilableTasks")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetAvilableTasks([FromHeader]string userName)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(userName);
                if (await _iUnitOfWork.tasksRepository.IsExistTask(user))
                {
                    IEnumerable<Tasks> tasks = await _iUnitOfWork.tasksRepository.GetByUser(user);

                    return Ok(tasks);
                }
                return BadRequest("Invalid Tasks");
            }
            return BadRequest("Invalid UserName");
        }

        [HttpPost("SubmitTasks")]
        public async Task<ActionResult<IEnumerable<Tasks>>> SubmitTasks(ClientSubmitTaskDTO clientSubmitTaskDTO)
        {
            if (await _iUnitOfWork.tasksRepository.IsExistTask(new Guid(clientSubmitTaskDTO.taskGUID)))
            {
                Tasks task = await _iUnitOfWork.tasksRepository.GetById(new Guid(clientSubmitTaskDTO.taskGUID));
                Processes processes = await _iUnitOfWork.processRepository.GetById(task.processId);
                Processes nextProcesses = await _iUnitOfWork.processRepository.GetById(processes.nextProcessIdNo1);
                
                Tasks nextTask = new Tasks()
                {
                    taskName = "Task",
                    createOn = DateTime.Now,
                    outhUser = nextProcesses.outhUser,
                    process = nextProcesses
                };

                _iUnitOfWork.tasksRepository.RemoveTask(task);
                await _iUnitOfWork.tasksRepository.addNewTask(nextTask);
                //Save all changes
                await _iUnitOfWork.Complete();

                return Ok();
            }
            return BadRequest("Invalid UserName");
        }
    }
}