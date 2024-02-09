using LanguageExt.Common;

namespace Shared.Querys
{
    public interface IQuery<D>
    {
        public Task<Result<D?>> GetAsync(string id);
    }

    internal interface IQueryTyped<D>
    { 
        public Task<D?> GetAsync(object id);
    }
}
