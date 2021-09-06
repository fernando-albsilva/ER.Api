using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Aplication.Aplication.Auth.User.Read.Model;

namespace ERapi.Services
{
   
        public static class TokenService
        {
            public static string GenerateToken(UserModel user)
            {
               
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor 
                { 
                    Subject = new ClaimsIdentity(new Claim[]
                    { 
                        new Claim(ClaimTypes.Name,user.UserName.ToString()),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    }),
                    // tempo de expiração do token
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials( new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                
                var token = tokenHandler.CreateToken(tokenDescriptor);
                 return tokenHandler.WriteToken(token);
            }
        }

        public static class Settings
        {
             public static string Secret = "cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e";
        }
    
}
