using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Users;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet("fake/getuser", Name = "GetFakeUser")]
        public Task<UserDto?> GetFakeUser(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("fake/createuser", Name = "FakeCreateUser")]
        public UserDto PostFakeUser([FromBody] NewUserDto newUser)
        {
            throw new NotImplementedException();
        }
    }
}
