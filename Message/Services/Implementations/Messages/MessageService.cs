using Database;
using LanguageExt;
using LanguageExt.Common;
using Services.Messages;
using Shared.Infra.Helpers;
using Shared.Infra.Extensions;
using System.ComponentModel.DataAnnotations;
using MongoDB.Driver;
using Shared.Infra;
using Shared.Dtos.Interactions.Messages;
using Domain.Entities;
using Domain;

namespace Services.Implementations.Messages
{
    public class MessageServiceBuilder : IBuilder<IMessageService>
    {
        private readonly IMapper<Message, MessageDto> _mapper;
        private readonly Lazy<IDbContext<Message>> _dbContext;

        public MessageServiceBuilder(Lazy<IDbContext<Message>> dbContext, IMapper<Message, MessageDto> mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IMessageService Build(string context)
        {
            return new MessageService(context, _dbContext, _mapper);
        }
    }

    public class MessageService : IMessageService
    {
        private readonly string _ownerId;
        private readonly IMapper<Message, MessageDto> _mapper;
        private readonly Lazy<IDbContext<Message>> _dbContext;

        public MessageService(string ownerId, Lazy<IDbContext<Message>> dbContext, IMapper<Message, MessageDto> mapper)
        {
            _dbContext = dbContext;
            _ownerId = ownerId;
            _mapper = mapper;
        }

        public async Task<Result<MessageDto>> CreateAsync(MessageDto dto)
        {
            var message = _mapper.DtoToNewEnt(dto);

            var collection = _dbContext.Value.GetDatabase().GetCollection<Message>(_ownerId);
            await collection.InsertOneAsync(message);

            return new Result<MessageDto>(_mapper.EntToDto(message));
        }

        public async Task<Result<MessageDto>> UpdateAsync(MessageDto dto)
        {
            var message = _mapper.DtoToEnt(dto);

            var collection = _dbContext.Value.GetDatabase().GetCollection<Message>(_ownerId);
            var result = await collection.ReplaceOneAsync(d => d.Id == message.Id, message);

            if (result.IsAcknowledged)
            {
                return new Result<MessageDto>(_mapper.EntToDto(message));
            }

            return new Result<MessageDto>(new ValidationException("Message not found."));
        }

        public async Task<Result<Unit>> DeleteAsync(string id)
        {
            var validationResult = PrimaryKeyHelper.ValidateIdGetConverted<MessageDto>(id);
            if (validationResult.IsFaulted)
            {
                return validationResult.NewWithException<object, Unit>();
            }

            var cid = (Guid)validationResult.GetValue();

            var collection = _dbContext.Value.GetDatabase().GetCollection<MessageDto>(_ownerId);
            var result = await collection.DeleteOneAsync(d => d.Id == cid);

            if (result.IsAcknowledged)
            {
                return new Result<Unit>(Unit.Default);
            }

            return new Result<Unit>(new ValidationException("Message not found."));
        }
    }
}
