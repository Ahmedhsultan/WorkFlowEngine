using Database.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WorkFlowEngine.Models.Interfaces;

namespace WorkFlowEngine.Models.Services
{
    public class TokenServices : ITokenServices
    {
        #region Dependance Injection and create security key
        private readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration _config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
        }
        #endregion

        public string GetToken(User user)
        {
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.userName),
            };

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(5),
                SigningCredentials = creds
            };

            var tokenhandeler = new JwtSecurityTokenHandler();

            var token = tokenhandeler.CreateToken(tokenDescriptor);

            return tokenhandeler.WriteToken(token);
        }
    }
}
