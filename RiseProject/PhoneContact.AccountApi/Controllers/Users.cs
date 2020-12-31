using Microsoft.AspNetCore.Mvc;
using PhoneContact.Core.Model.Request;
using PhoneContact.Engine.Abstract;
using System.Threading.Tasks;

namespace PhoneContact.AccountApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUSerServices _User;
        public UsersController(IUSerServices user)
        {
            _User = user;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthenticateRequestModel requestModel)
        {
            var result = (await _User.Authenticate(requestModel.UserName, requestModel.PassWord));
            if (result == null)
            {
                return BadRequest("Kullanıcı bilgilerini kontrol ediniz");
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
