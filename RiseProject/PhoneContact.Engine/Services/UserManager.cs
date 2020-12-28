using Microsoft.IdentityModel.Tokens;
using PhoneContact.Core.Helpers;
using PhoneContact.Data.Abstract;
using PhoneContact.Engine.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PhoneContact.Engine.Services
{
    public class UserManager : BusinessEngineBase, IUSerService
    {
        private readonly IUnitOfWork _Uow;
        private readonly AppSettings _appSettings;
        public UserManager(IUnitOfWork Uow, AppSettings appSettings)
        {
            _appSettings = appSettings;
            _Uow = Uow;
        }
        public Task<UserResponse> Authenticate(string username, string password)
        {
            return ExecuteWithExceptionHandledOperation(async () =>
           {
               var user = await _Uow.UserRepostiyory.GetEntityAsync(o => o.UserName == username && o.Password == password);
               if (user == null)
               {
                   return null;

               }
               else
               {
                   var tokenHandler = new JwtSecurityTokenHandler();
                   var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
                   var tokenDesc = new SecurityTokenDescriptor
                   {
                       Subject = new ClaimsIdentity(new[]

                       {
                           new Claim("userId", user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                   }),
                       Expires = DateTime.UtcNow.AddMinutes(2),
                       SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                   };
                   var token = tokenHandler.CreateToken(tokenDesc);
                   string generatedToken = tokenHandler.WriteToken(token);
                   return new UserResponse()
                   {
                       UserName = user.UserName,
                       Token = generatedToken
                   };
               }
           });
        }
    }
}
