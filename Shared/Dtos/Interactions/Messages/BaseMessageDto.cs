using Shared.Dtos.Basic;

namespace Shared.Dtos.Interactions.Messages
{
    public class BaseMessageDto : PrimaryKeyDto<Guid?>
    {
        public BaseMessageDto()
        {
            Text = string.Empty;
        }

        public BaseMessageDto(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public DateTimeOffset? Time { get; set; }
        public Guid UserId { get; set; }
    }
}
