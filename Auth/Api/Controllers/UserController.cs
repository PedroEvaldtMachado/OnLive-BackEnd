using Api.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Querys.Users;
using Services.Users;
using Shared.Dtos.Users;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController(
        Lazy<IUserQuery> userQuery, 
        Lazy<IUserService> userService) : ControllerBase
    {
        private readonly Lazy<IUserQuery> _userQuery = userQuery;
        private readonly Lazy<IUserService> _userService = userService;

        [HttpGet("fake/getuser", Name = "GetFakeUser")]
        public async Task<IActionResult> GetFakeUser(string id)
        {
            var user = await _userQuery.Value.GetAsyncCached(id);

            return user.ApiResult(u => u);
        }

        [HttpPost("fake/createuser", Name = "FakeCreateUser")]
        public IActionResult PostFakeUser([FromBody] NewUserDto newUser)
        {
            var user = _userService.Value.CreateFakeUser(newUser.Username, newUser.Email);

            return user.ApiResult(u => u);
        }
    }
}
