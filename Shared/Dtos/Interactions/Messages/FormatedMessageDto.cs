namespace Shared.Dtos.Interactions.Messages
{
    public class FormatedMessageDto : BaseMessageDto
    {
        public FormatedMessageDto()
        {
        }

        public FormatedMessageDto(string text) : base(text)
        {
        }

        public string? Color { get; set; }
        public string? Format { get; set; }
    }
}
