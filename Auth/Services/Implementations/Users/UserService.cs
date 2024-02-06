using LanguageExt.Common;
using Microsoft.Extensions.Caching.Distributed;
using Services.Users;
using Shared.Dtos.Users;
using Shared.Infra.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Services.Implementations.Users
{
    class UserService : IUserService
    {
        private readonly Lazy<IDistributedCache> _cache;

        public UserService(Lazy<IDistributedCache> cache)
        {
            _cache = cache;
        }

        public Result<UserDto> CreateFakeUser(string? username, string email)
        {
            if (username is null)
            {
                return new Result<UserDto>(new ValidationException("'username' required"));
            }

            var user = new UserDto(username, email)
            {
                Id = Guid.NewGuid()
            };

            _cache.Value.SetAsync(user!.Id, user!);

            return new Result<UserDto>(user);
        }
    }
}
