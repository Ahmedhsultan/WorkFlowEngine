using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WorkFlowEngine.Models.DTOs.Forms;

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
        public async Task<ActionResult> PostForm(PostForm postForm)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(postForm.userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(postForm.userName);

                List<User> adminDigramUsers = new List<User>();
                foreach (var outhUserName in postForm.adminUsers)
                {
                    adminDigramUsers.Add(await _iUnitOfWork.userRepository.GetByUserName(outhUserName));
                }

                if (!await _iUnitOfWork.formRepository.IsExistform(user, postForm.formName))
                {
                    Forms form = new Forms()
                    {
                        formName = postForm.formName,
                        html = postForm.htmlForm,
                        json = postForm.jsonForm,
                        adminUsers = adminDigramUsers
                    };
                    await _iUnitOfWork.formRepository.addNewForm(form);
                }
                else
                {
                    //edit exist form
                }

                //Save all changes
                await _iUnitOfWork.Complete();
                return Ok();
            }
            return BadRequest("Invalid UserName");
        }

        [HttpGet("GetForms")]
        public async Task<ActionResult<IEnumerable<Forms>>> GetForms([FromHeader] string userName)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(userName);
                if (await _iUnitOfWork.formRepository.IsExistform(user))
                {
                    IEnumerable<Forms> forms = await _iUnitOfWork.formRepository.GetByUser(user);

                    return Ok(forms);
                }
                return BadRequest("Invalid Forms");
            }
            return BadRequest("Invalid UserName");
        }

        [HttpGet("GetForm")]
        public async Task<ActionResult<Forms>> GetForm(GetFormDTO getFormDTO)
        {
            if (await _iUnitOfWork.userRepository.ExistUserName(getFormDTO.userName))
            {
                User user = await _iUnitOfWork.userRepository.GetByUserName(getFormDTO.userName);
                if (await _iUnitOfWork.formRepository.IsExistform(new Guid(getFormDTO.formGuid)))
                {
                    Forms form = await _iUnitOfWork.formRepository.GetById(new Guid(getFormDTO.formGuid));
                    /*
                                        FormDTO formDTO = new FormDTO()
                                        {
                                            userName = user.userName,
                                            formGuid = form.formName,
                                            htmlForm = form.html,
                                            jsonForm = form.json,
                                            outhUsers = form.adminUsers
                                        };*/

                return Ok(form);
                }
                return BadRequest("Invalid Form");
            }
            return BadRequest("Invalid UserName");
        }
    }
}
