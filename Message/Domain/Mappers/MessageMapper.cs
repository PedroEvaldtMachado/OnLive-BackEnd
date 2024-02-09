using Domain.Entities;
using Shared.Dtos.Interactions.Messages;

namespace Domain.Mappers
{
    public class MessageMapper : IMapper<Message, MessageDto>
    {
        public MessageDto EntToDto(Message ent)
        {
            return new MessageDto 
            { 
                Id = ent.Id,
                RepliedMessageId = ent.RepliedMessageId,
                Color = ent.Color,
                Format = ent.Format,
                Text = ent.Text,
                Time = ent.Time,
                UserId = ent.UserId
            };
        }

        public Message DtoToEnt(MessageDto dto)
        {
            return new Message
            {
                Id = dto.Id ?? Guid.Empty,
                Text = dto.Text,
                Time = dto.Time ?? DateTimeOffset.UtcNow,
                UserId = dto.UserId,
                RepliedMessageId = dto.RepliedMessageId,
                Color = dto.Color,
                Format = dto.Format
            };
        }

        public Message DtoToNewEnt(MessageDto dto)
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                Text = dto.Text,
                Time = DateTimeOffset.UtcNow,
                UserId = dto.UserId,
                RepliedMessageId = dto.RepliedMessageId,
                Color = dto.Color,
                Format = dto.Format
            };
        }
    }
}
