using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WorkFlowEngine.Models.DTOs.TempStorage;
using WorkFlowEngine.Models.Interfaces;

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TempStorageController : Controller
    {
        #region Dependancy Injection
        private IUnitOfWork _UniteOfWork;
        private ITokenServices _Tokenservice;
        public TempStorageController(IUnitOfWork _iUniteOfWork, ITokenServices _tokenservice)
        {
            this._UniteOfWork = _iUniteOfWork;
            this._Tokenservice = _tokenservice;
        }
        #endregion


        [HttpPost("addData")]
        public async Task<ActionResult> addData(AddTempDataDTO data)
        {
            _UniteOfWork.tempStorageRepository.removeALll();
            await _UniteOfWork.Complete();

            TempStorage tempStorage = new TempStorage()
            {
                data = data.data
            };
            _UniteOfWork.tempStorageRepository.addData(tempStorage);

            await _UniteOfWork.Complete();
            return Ok();
        }

        [HttpGet("getData")]
        public async Task<ActionResult<string>> getData()
        {
            ICollection<TempStorage> tempStorage = await _UniteOfWork.tempStorageRepository.getAll();
            if (tempStorage != null)
            {
                foreach (var temp in tempStorage)
                {
                    string data = temp.data;
                    _UniteOfWork.tempStorageRepository.removeALll();
                    await _UniteOfWork.Complete();
                    return Ok(data);
                }
            }

            return BadRequest();
        }
    }
}
