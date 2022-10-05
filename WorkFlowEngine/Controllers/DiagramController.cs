#region Library
using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WorkFlowEngine.Models.DTOs.ProccesDigram;
using WorkFlowEngine.Models.Services.ProcessServices.CreateNodeList;
#endregion

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DiagramController : Controller
    {
        #region Debendancy injection
        private readonly IUnitOfWork _iUnitOfWork;
        public DiagramController(IUnitOfWork _iUnitOfWork)
        {
            this._iUnitOfWork = _iUnitOfWork;
        }
        #endregion


        [HttpPost("PostDiagram")]
        public async Task<ActionResult> PostDiagram(DigramDTO digramDTO)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(digramDTO.userName.ToLower()))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(digramDTO.userName);
                List<User> adminDigramUsers = new List<User>();
                adminDigramUsers.Add(user);
                /*foreach (var outhUserName in digramDTO.adminUserName)
                {
                    adminDigramUsers.Add(await _iUnitOfWork.userRepository.GetByUserName(outhUserName));
                }
                List<User> initiateDigramUsers = new List<User>();
                foreach (var initiateUserName in digramDTO.initiateUserName)
                {
                    initiateDigramUsers.Add(await _iUnitOfWork.userRepository.GetByUserName(initiateUserName));
                }*/
                Digrams digram = new Digrams()
                {
                    digramId = digramDTO.digramId,
                    digramName = digramDTO.digramName,
                    digramJson = digramDTO.diagramJson,
                    adminUsers = adminDigramUsers,
                };

                //Add to digram table
                if (await _iUnitOfWork.digramsRepository.IsExistDigram(digramDTO.digramId))
                    await _iUnitOfWork.digramsRepository.RemoveDigrame(digramDTO.digramId);

                await _iUnitOfWork.Complete();
                await _iUnitOfWork.digramsRepository.addNewDigram(digram);

                //Add to process table
                GetProccesListFromDiagram getProccesListFromDiagram = new GetProccesListFromDiagram(digramDTO.diagramJson);
                foreach (var process in getProccesListFromDiagram.Nodelist)
                {
                    List<User> outhUserList = new List<User>();
                    foreach (string outhUserName in process.outhUser)
                    {
                        outhUserList.Add(await _iUnitOfWork.userRepository.GetByUserName(outhUserName));
                    }

                    await _iUnitOfWork.processRepository.addNewProcess(new Processes()
                    {
                        processId = process.processId,
                        digram = digram,
                        formId = process.formId,
                        outhUser = outhUserList,
                        GitwayVarKey = process.GitwayVarKey,
                        GitwayVarValu = process.GitwayVarValu,
                        nextProcessIdNo1 = process.nextProcessIdNo1,
                        nextProcessIdNo2 = process.nextProcessIdNo2,
                        unanimousOrOdds = process.unanimousOrOdds
                    });
                }
                await _iUnitOfWork.Complete();

                //Add to request table
                await _iUnitOfWork.requestsRepository.addNewRequest(new Requests()
                {
                    //check no2
                    startProcesses = await _iUnitOfWork.processRepository.GetById(getProccesListFromDiagram.startNodeGuid),
                    user = adminDigramUsers
                });

                //Save all changes
                await _iUnitOfWork.Complete();

                return Ok();
            }
            return BadRequest("Invalid UserName");
        }

        [HttpGet("GetAllDiagrams")]
        public async Task<ActionResult<IEnumerable<Digrams>>> GetAllDiagrams([FromHeader] string userName)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(userName);
                if (await _iUnitOfWork.digramsRepository.IsExistDigram(user))
                {
                    IEnumerable<Digrams> digrams = await _iUnitOfWork.digramsRepository.GetByUser(user);

                    return Ok(digrams);
                }
                return BadRequest("Invalid Digrams");
            }
            return BadRequest("Invalid UserName");
        }

        [HttpGet("GetDiagram")]
        public async Task<ActionResult<DigramDTO>> GetDiagram([FromHeader] GetDigramDTO getDigramDTO)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(getDigramDTO.userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(getDigramDTO.userName);
                if (await _iUnitOfWork.digramsRepository.IsExistDigram(new Guid(getDigramDTO.digramGUID)))
                {
                    Digrams digram = await _iUnitOfWork.digramsRepository.GetById(new Guid(getDigramDTO.digramGUID));

                    DigramDTO digramDTO = new DigramDTO()
                    {
                        userName = user.userName,
                        digramId = digram.digramId,
                        digramName = digram.digramName,
                        diagramJson = digram.digramJson
                    };

                    return Ok(digramDTO);
                }
                return BadRequest("Invalid Digram");
            }
            return BadRequest("Invalid UserName");
        }
    }
}