
using Aplication.Auth.User.Domain.Read.Model;
using Application.Auth.Domain.Read.Repositories;
using Application.Auth.User.Domain.Write.Commands;
using AuthenticationPlugin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ERapi.Controllers
{

    //GET  /Functions

    [ApiController]
    [Route("authorize")]
   
    public class AuthorizationController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly AuthService _auth;
        private readonly IBaseReadUserRepository readUserRepository;

        public AuthorizationController(IBaseReadUserRepository readUserRepository, IConfiguration configuration)
        {
            _configuration = configuration;
            _auth = new AuthService(_configuration);
            this.readUserRepository = readUserRepository;
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] AuthUserCommand cmd)
        {
            var user = readUserRepository.GetByUser(cmd.UserName);

            if (user == null)
            {
                return NotFound(new { message = "Nome de usuário ou senha incorreta" });
            }

            if (!SecurePasswordHasherHelper.Verify(cmd.Password, user.Password))
            {
                return Unauthorized(new { message = "Nome de usuário ou senha incorreta" });
            }

            var claims = new[]
             {
               new Claim(JwtRegisteredClaimNames.Email, user.UserName),
               new Claim(ClaimTypes.Email, user.UserName),
               new Claim(ClaimTypes.Role,user.Role)

             };

            var token = _auth.GenerateAccessToken(claims);

            var userValidation = new {
                Id = user.Id,
                UserName = user.UserName,
                Role = user.Role,
            };

            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user = userValidation
            });
        }
    }

} 