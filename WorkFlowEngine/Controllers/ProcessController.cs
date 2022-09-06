#region Library
using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WorkFlowEngine.Models.DTOs.ProccesDigram;
#endregion

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProcessController : Controller
    {
        #region Debendancy injection
        private readonly IUnitOfWork _iUnitOfWork;
        public ProcessController(IUnitOfWork _iUnitOfWork)
        {
            this._iUnitOfWork = _iUnitOfWork;
        }
        #endregion


        [HttpPost("CreateDigram")]
        public async Task<ActionResult> CreateDigram(DigramDTO digramDTO)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(digramDTO.userName.ToLower()))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(digramDTO.userName);
                List<User> adminDigramUsers = new List<User>();
                foreach (var outhUserName in digramDTO.adminUserName)
                {
                    adminDigramUsers.Add(await _iUnitOfWork.userRepository.GetByUserName(outhUserName));
                }
                List<User> initiateDigramUsers = new List<User>();
                foreach (var initiateUserName in digramDTO.initiateUserName)
                {
                    initiateDigramUsers.Add(await _iUnitOfWork.userRepository.GetByUserName(initiateUserName));
                }
                Digrams digram = new Digrams()
                {
                    digramId = digramDTO.digramId,
                    digramName = digramDTO.digramName,
                    adminUsers = adminDigramUsers,
                };

                //Add to digram table
                if (await _iUnitOfWork.digramsRepository.IsExistDigram(digramDTO.digramId))
                    await _iUnitOfWork.digramsRepository.RemoveDigrame(digramDTO.digramId);

                await _iUnitOfWork.Complete();
                await _iUnitOfWork.digramsRepository.addNewDigram(digram);

                //Add to process table
                foreach (var process in digramDTO.ProcessList)
                {
                    List<User> outhUserList = new List<User>();
                    foreach (string outhUserName in process.usersOthenticated)
                    {
                        outhUserList.Add(await _iUnitOfWork.userRepository.GetByUserName(outhUserName));
                    }

                    await _iUnitOfWork.processRepository.addNewProcess(new Processes()
                    {
                        processId = new Guid(process.processId),
                        digram = digram,
                        formId = new Guid(process.form),
                        scriptId = new Guid(process.script),
                        start = process.start,
                        end = process.end,
                        outhUser = outhUserList,
                        nextProcessIdNo1 = new Guid(process.nextProcessIdNo1),
                        nextProcessIdNo2 = new Guid(process.nextProcessIdNo2),
                    });
                }
                await _iUnitOfWork.Complete();

                //Add to request table
                await _iUnitOfWork.requestsRepository.addNewRequest(new Requests()
                {
                    //check no2
                    startProcesses = await _iUnitOfWork.processRepository.GetById(new Guid(digramDTO.ProcessList[0].processId)),
                    user = initiateDigramUsers
                });

                //Save all changes
                await _iUnitOfWork.Complete();

                return Ok();
            }
            return BadRequest("Invalid UserName");
        }

        [HttpPost("GetDigram")]
        public async Task<ActionResult<DigramDTO>> GetDigram(GetDigramDTO getDigramDTO)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(getDigramDTO.userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(getDigramDTO.userName);
                if (await _iUnitOfWork.digramsRepository.IsExistDigram(user))
                {
                    Digrams digram = await _iUnitOfWork.digramsRepository.GetByUser(user);

                    DigramDTO digramDTO = new DigramDTO()
                    {
                        userName = user.userName,
                        digramId = digram.digramId,
                        digramName = digram.digramName,
                        ProcessList = null
                    };

                    return Ok(digramDTO);
                }
                return BadRequest("Invalid Digram");
            }
            return BadRequest("Invalid UserName");
        }
    }
}