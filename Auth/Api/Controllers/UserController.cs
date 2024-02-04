using Microsoft.AspNetCore.Mvc;
using Querys.Users;
using Services.Users;
using Shared.Dtos.Users;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Lazy<IUserQuery> _userQuery;
        private readonly Lazy<IUserService> _userService;

        public UserController(Lazy<IUserQuery> userQuery, Lazy<IUserService> userService)
        {
            _userQuery = userQuery;
            _userService = userService;
        }

        [HttpGet("fake/getuser", Name = "GetFakeUser")]
        public async Task<UserDto?> GetFakeUser(string id)
        {
            var user = await _userQuery.Value.GetAsyncCached(id);

            return user;
        }

        [HttpPost("fake/createuser", Name = "FakeCreateUser")]
        public UserDto PostFakeUser([FromBody] NewUserDto newUser)
        {
            var user = _userService.Value.CreateFakeUser(newUser.Username, newUser.Email);

            return user;
        }
    }
}
