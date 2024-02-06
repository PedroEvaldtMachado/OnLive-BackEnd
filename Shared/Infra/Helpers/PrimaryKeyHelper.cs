using LanguageExt.Common;
using System.ComponentModel.DataAnnotations;

namespace Shared.Infra.Helpers
{
    public static class PrimaryKeyHelper
    {
        private const string CANNOT_BE_NULL = "'Id' cannot be null.";
        private const string NEED_TO_BE_A_GUID = "'Id' need to be a guid.";

        public static Result<Guid> ValidateIdGetGuid(string id)
        {
            if (id is null)
            {
                return new Result<Guid>(new ValidationException(CANNOT_BE_NULL));
            }

            if (Guid.TryParse(id, out var guid))
            {
                return guid;
            }
            else
            {
                return new Result<Guid>(new ValidationException(NEED_TO_BE_A_GUID));
            }
        }
    }
}
