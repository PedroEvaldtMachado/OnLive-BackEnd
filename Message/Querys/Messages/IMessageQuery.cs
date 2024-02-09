using Shared.Dtos.Interactions.Messages;
using Shared.Querys;

namespace Querys.Messages
{
    public interface IMessageQuery : IQuery<MessageDto>, IQueryCached<MessageDto>
    {
        Task<IEnumerable<MessageDto>> GetAllAsync();
        Task<IEnumerable<MessageDto>> GetAllAfterAsync(DateTimeOffset afterTime);
    }
}
