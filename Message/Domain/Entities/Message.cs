namespace Domain.Entities
{
    public class Message : Base<Guid>
    {
        public required string Text { get; set; }
        public DateTimeOffset Time { get; set; }
        public Guid UserId { get; set; }
        public string? Color { get; set; }
        public bool Bold { get; set; }
        public Guid? RepliedMessageId { get; set; }
        public string? Format { get; set; }
    }
}
