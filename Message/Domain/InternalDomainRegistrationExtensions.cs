using Domain.Entities;
using Domain.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Shared.Dtos.Interactions.Messages;

namespace Domain
{
    public static class InternalDomainRegistrationExtensions
    {
        public static IServiceCollection AddInternalDomain(this IServiceCollection services)
        {
            services.AddScoped<IMapper<Message, MessageDto>, MessageMapper>();

            return services;
        }
    }
}
