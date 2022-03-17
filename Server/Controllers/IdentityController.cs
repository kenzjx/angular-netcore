using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Server.Data.Models;
using Server.Models.Identity;

namespace Server.Controllers
{
       public  class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings _appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            _appSettings = appSettings.Value;
        }
        [Route(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.UserName

            };
            var result = await this.userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Errors);

        }

        [Route(nameof(Login))]
        public async Task<ActionResult<string>> Login( LoginRequestModel model)
        {

            var user = await userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                return Unauthorized();
            }
            
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            
            if(!passwordValid)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString() )
                }),

                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            var encrytedToken = tokenHandler.WriteToken(token);
            return encrytedToken;
        }
    }
}