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
            if (await _iUnitOfWork.userRepository.ExistUserName(digramDTO.userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(digramDTO.userName);
                Digrams digram = new Digrams()
                {
                    DigramName = digramDTO.digramName,
                };

                //Add to digram table
                await _iUnitOfWork.digramsRepository.addNewDigram(digram);

                //Add to process table
                foreach (var process in digramDTO.ProcessList)
                {
                    await _iUnitOfWork.processRepository.addNewProcess(new Processes()
                    {
                        digram = digram,
                        form = new Guid(process.form),
                        script = new Guid(process.script),
                        start = process.start,
                        end = process.end,
                        nextProcessIdNo1 = new Guid(process.nextProcessIdNo1),
                        nextProcessIdNo2 = new Guid(process.nextProcessIdNo2),
                    });
                }

                //Add to request table
                await _iUnitOfWork.requestsRepository.addNewRequest(new Requests()
                {
                    //check no2
                    startProcesses = await _iUnitOfWork.processRepository.GetById(new Guid(digramDTO.ProcessList[0].nextProcessIdNo1)),
                    user = user
                });

                //Save all changes
                await _iUnitOfWork.Complete();

                return Ok();
            }
            return BadRequest("Invalid UserName");
        }
    }
}
