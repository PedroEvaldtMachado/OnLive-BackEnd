namespace Shared.Dtos.Interactions.Messages
{
    public class MessageDto : FormatedMessageDto
    {
        public Guid? RepliedMessageId { get; set; }
    }
}
