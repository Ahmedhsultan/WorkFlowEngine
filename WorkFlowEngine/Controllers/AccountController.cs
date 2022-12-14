#region libraries
using Database.Models;
using Database.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WorkFlowEngine.Models.DTOs.Account;
using WorkFlowEngine.Models.Interfaces;
#endregion

namespace WorkFlowEngine.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : Controller
    {
        #region Dependancy Injection
        private IUnitOfWork _UniteOfWork;
        private ITokenServices _Tokenservice;
        public AccountController(IUnitOfWork _iUniteOfWork, ITokenServices _tokenservice)
        {
            this._UniteOfWork = _iUniteOfWork;
            this._Tokenservice = _tokenservice;
        }
        #endregion

        #region Registration EndPoints
        [HttpPost("Register")]
        public async Task<ActionResult<UserToClientDTO>> Register(RegisterUserDTO userDTO)
        {
            //Check if this userName is used from other user
            if (!await _UniteOfWork.userRepository.ExistUserName(userDTO.userName.ToLower()))
            {
                //Hashing the password befor saving in database
                using var hmac = new HMACSHA512();

                var user = new User
                {
                    userName = userDTO.userName.ToLower(),
                    email = userDTO.email.ToLower(),
                    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.password)),
                    passwordSult = hmac.Key,
                    firstName = userDTO.firstName,
                    lastName = userDTO.lastName,
                    role = userDTO.role,
                    createdOn = DateTime.Now,
                    gender = userDTO.gender
                };
                //Add user to databse
                await _UniteOfWork.userRepository.addNewUser(user);
                await _UniteOfWork.Complete();

                return Ok(/*new UserToClientDTO()
                {
                    userName = user.userName,
                    token = _Tokenservice.GetToken(user)
                }*/);
            }
            return BadRequest("UserName is taken");
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToClientDTO>> Login(LoginUserDTO loginDTO)
        {
            //Check if username is right
            if (await _UniteOfWork.userRepository.ExistUserName(loginDTO.userName.ToLower()))
            {
                //Get user from databse
                User user = await _UniteOfWork.userRepository.GetByUserName(loginDTO.userName.ToLower());

                //Hash password which enterd by client
                using var hmac = new HMACSHA512(user.passwordSult);
                byte[] loginPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

                //Compare between client password and the password wich exist in database
                for (int i = 0; i < loginPasswordHash.Length; i++)
                    if (loginPasswordHash[i] != user.passwordHash[i])
                        return Unauthorized("Password is wrong");

                return Ok(new UserToClientDTO()
                {
                    userName = user.userName,
                    email = user.email,
                    firstName= user.firstName,
                    lastName = user.lastName,
                    Gender = user.gender,
                    role = user.role.ToString(),
                    token = _Tokenservice.GetToken(user)
                });
            }
            return Unauthorized("Invalid Username");
        }
        #endregion
    }
}