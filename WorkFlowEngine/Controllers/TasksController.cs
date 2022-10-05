#region Library
using Database.Models;
using Database.Models.Enums;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
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
        public async Task<ActionResult<IEnumerable<Tasks>>> GetAvilableTasks([FromHeader] string userName)
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

        [HttpPost("SubmitTask")]
        public async Task<ActionResult<IEnumerable<Tasks>>> SubmitTask(ClientSubmitTaskDTO clientSubmitTaskDTO)
        {
            if (await _iUnitOfWork.tasksRepository.IsExistTask(new Guid(clientSubmitTaskDTO.taskGUID)))
            {
                Tasks task = await _iUnitOfWork.tasksRepository.GetById(new Guid(clientSubmitTaskDTO.taskGUID));
                Processes processes = await _iUnitOfWork.processRepository.GetById(task.processId);
                User user = await _iUnitOfWork.userRepository.GetByUserName(clientSubmitTaskDTO.userName);


                //If  Submisstion from outhuser of the task is odds
                if (processes.unanimousOrOdds == UnanimousOrOdds.Unanimous)
                {
                    ICollection<User> outhusers = task.outhUser;
                    outhusers.Remove(user);

                    task.outhUser = outhusers;
                }


                //Check if Submisstion from outhuser of the task is unanimous or odds
                if (processes.unanimousOrOdds == UnanimousOrOdds.Odds || task.outhUser.Count == 0)
                {
                    //Check if its the final process
                    if (processes.nextProcessIdNo1 != Guid.Empty)
                    {
                        //Get wich is the Next Process
                        Processes nextProcesses = await _iUnitOfWork.processRepository.GetById(processes.nextProcessIdNo1);
                        if (processes.nextProcessIdNo2 != Guid.Empty)
                        {
                            Processes nextProcessIdNo1 = await _iUnitOfWork.processRepository.GetById(processes.nextProcessIdNo1);
                            if (nextProcessIdNo1.GitwayVarKey != "")
                                foreach (var var in clientSubmitTaskDTO.varList)
                                    if (var.key == nextProcessIdNo1.GitwayVarKey)
                                        if (var.value == nextProcessIdNo1.GitwayVarValu)
                                            nextProcesses = await _iUnitOfWork.processRepository.GetById(processes.nextProcessIdNo1);

                            Processes nextProcessIdNo2 = await _iUnitOfWork.processRepository.GetById(processes.nextProcessIdNo2);
                            if (nextProcessIdNo2.GitwayVarKey != "")
                                foreach (var var in clientSubmitTaskDTO.varList)
                                    if (var.key == nextProcessIdNo2.GitwayVarKey)
                                        if (var.value == nextProcessIdNo2.GitwayVarValu)
                                            nextProcesses = await _iUnitOfWork.processRepository.GetById(processes.nextProcessIdNo2);
                        }

                        //Get all variables from old task
                        ICollection<FormVariable> formVariables = new Collection<FormVariable>();
                        foreach (var variable in clientSubmitTaskDTO.varList)
                        {
                            formVariables.Add(new FormVariable()
                            {
                                Key = variable.key,
                                value = variable.value
                            });
                        }

                        //Create New Task
                        Tasks nextTask = new Tasks()
                        {
                            taskName = "Task",
                            createOn = DateTime.Now,
                            outhUser = nextProcesses.outhUser,
                            runningRequests = task.runningRequests,
                            process = nextProcesses,
                            formVariable = formVariables
                        };

                        //Add new task
                        await _iUnitOfWork.tasksRepository.addNewTask(nextTask);
                    }

                    //Remove Old Task
                    _iUnitOfWork.tasksRepository.RemoveTask(task);
                }
                //Save all changes
                await _iUnitOfWork.Complete();

                return Ok();
            }
            return BadRequest("Invalid UserName");
        }
    }
}