using Shared.Dtos.Basic;

namespace Shared.Dtos.Interactions.Messages
{
    public class MessageDto : PrimaryKeyDto
    {
        public MessageDto()
        {
            Text = string.Empty;
            Time = DateTime.MinValue;
        }

        public MessageDto(string text, DateTimeOffset time)
        {
            Text = text;
            Time = time;
        }

        public string Text { get; set; }
        public DateTimeOffset Time { get; }
    }
}
