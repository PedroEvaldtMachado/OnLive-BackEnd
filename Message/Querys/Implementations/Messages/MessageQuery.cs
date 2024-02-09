using Database;
using Domain;
using Domain.Entities;
using LanguageExt;
using LanguageExt.Common;
using LanguageExt.Pipes;
using MongoDB.Driver;
using Querys.Messages;
using Shared.Dtos.Interactions.Messages;
using Shared.Infra;
using Shared.Infra.Extensions;
using Shared.Infra.Helpers;
using Shared.Querys;
using Shared.Querys.Implementations;

namespace Querys.Implementations.Messages
{
    internal class MessageQueryBuilder : IBuilder<IMessageQuery>
    {
        private readonly IQueryCachedParams<MessageDto> _queryParams;
        private readonly IMapper<Message, MessageDto> _mapperMessage;
        private readonly Lazy<IDbContext<Message>> _dbContext;

        public MessageQueryBuilder(IQueryCachedParams<MessageDto> queryParams, Lazy<IDbContext<Message>> dbContext, IMapper<Message, MessageDto> mapperMessage)
        {
            _queryParams = queryParams;
            _dbContext = dbContext;
            _mapperMessage = mapperMessage;
        }

        public IMessageQuery Build(string context)
        {
            return new MessageQuery(context, _queryParams, _dbContext, _mapperMessage);
        }
    }

    internal class MessageQuery : QueryCached<MessageDto>, IMessageQuery
    {
        private readonly string _ownerId;
        private readonly IMapper<Message, MessageDto> _mapperMessage;
        private readonly Lazy<IDbContext<Message>> _dbContext;

        public MessageQuery(string ownerId, IQueryCachedParams<MessageDto> queryParams, Lazy<IDbContext<Message>> dbContext, IMapper<Message, MessageDto> mapperMessage) : base(queryParams)
        {
            _dbContext = dbContext;
            _ownerId = ownerId;
            _mapperMessage = mapperMessage;
        }

        public async Task<IEnumerable<MessageDto>> GetAllAsync()
        {
            var collection = _dbContext.Value.GetDatabase().GetCollection<Message>(_ownerId);
            var message = await collection.AsQueryable().ToListAsync();

            return message.Select(_mapperMessage.EntToDto);
        }

        public async Task<IEnumerable<MessageDto>> GetAllAfterAsync(DateTimeOffset afterTime)
        {
            var collection = _dbContext.Value.GetDatabase().GetCollection<Message>(_ownerId);
            var messagesAsync = await collection.FindAsync(d => d.Time > afterTime);
            var messages = await messagesAsync.ToListAsync();

            return messages.Select(_mapperMessage.EntToDto);
        }

        public async Task<Result<MessageDto?>> GetAsync(string id)
        {
            var validationResult = PrimaryKeyHelper.ValidateIdGetConverted<MessageDto>(id);
            if (validationResult.IsFaulted)
            { 
                return validationResult.NewWithException<object, MessageDto?>();
            }

            var message = await GetAsync(validationResult.GetValue());

            return new Result<MessageDto?>(message);
        }

        public override async Task<MessageDto?> GetAsync(object id)
        {
            var collection = _dbContext.Value.GetDatabase().GetCollection<Message>(_ownerId);
            var messageAction = await collection.FindAsync(d => d.Id == (Guid)id);
            var message = await messageAction.FirstAsync();

            return _mapperMessage.EntToDto(message);
        }
    }    
}
