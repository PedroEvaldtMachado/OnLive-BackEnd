using LanguageExt;
using LanguageExt.Common;
using Shared.Dtos.Interactions.Messages;

namespace Services.Messages
{
    public interface IMessageService
    {
        Task<Result<MessageDto>> CreateAsync(MessageDto dto);
        Task<Result<Unit>> DeleteAsync(string id);
        Task<Result<MessageDto>> UpdateAsync(MessageDto dto);
    }
}
