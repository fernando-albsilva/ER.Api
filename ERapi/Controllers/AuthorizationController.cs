
using Aplication.Auth.User.Domain.Read.Model;
using Application.Auth.Domain.Read.Repositories;
using ERapi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<dynamic> Authenticate([FromBody] UserModel userModel)
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