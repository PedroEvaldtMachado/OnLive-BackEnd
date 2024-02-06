using LanguageExt.Common;

namespace Shared.Querys
{
    public interface IQuery<D>
    {
        public Task<Result<D?>> GetAsync(string id);
    }

    internal interface IQueryGuid<D>
    { 
        public Task<D?> GetAsync(Guid id);
    }
}
