namespace Shared.Dtos.Interactions.Messages
{
    public class FormatedMessageDto : MessageDto
    {
        public FormatedMessageDto()
        {
            Format = Color = string.Empty;
            Things = new List<string>();
        }

        public FormatedMessageDto(string text, DateTimeOffset time) : base(text, time)
        {
            Things = new List<string>();
        }

        public string? Color { get; set; }
        public string? Format { get; set; }
        public ICollection<string> Things { get; set; }
    }
}
