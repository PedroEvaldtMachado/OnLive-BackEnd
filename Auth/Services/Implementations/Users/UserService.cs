using Microsoft.Extensions.Caching.Distributed;
using Services.Users;
using Shared.Dtos.Users;
using Shared.Infra.Extensions;

namespace Services.Implementations.Users
{
    class UserService : IUserService
    {
        private readonly Lazy<IDistributedCache> _cache;

        public UserService(Lazy<IDistributedCache> cache)
        {
            _cache = cache;
        }

        public UserDto CreateFakeUser(string? username, string email)
        {
            if (username is null)
            {
                throw new ArgumentNullException(nameof(username));
            }

            var user = new UserDto(username, email)
            {
                Id = Guid.NewGuid()
            };

            _cache.Value.SetAsync(user!.Id, user!);

            return user;
        }
    }
}
