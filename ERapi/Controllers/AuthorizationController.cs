
using Aplication.Auth.User.Domain.Write.Commands;
using Application.Auth.Domain.Read.Repositories;
using ERapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ERapi.Controllers
{

    //GET  /Functions

    [Route("authorize")]
   /* [ApiController]
    [Authorize]*/
    public class AuthorizationController : ControllerBase
    {
        private readonly IBaseReadUserRepository readUserRepository;

        public AuthorizationController(IBaseReadUserRepository readUserRepository)
        {
            this.readUserRepository = readUserRepository;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserCommand userModel)
        {

            var user = readUserRepository.GetByUser(userModel.UserName, userModel.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }
     

    }

} 