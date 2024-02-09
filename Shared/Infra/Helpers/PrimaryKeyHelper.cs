using LanguageExt.Common;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Shared.Infra.Helpers
{
    public static class PrimaryKeyHelper
    {
        private const string CANNOT_BE_NULL = "'Id' cannot be null.";
        private const string NEED_TO_BE_A_GUID = "'Id' need to be a guid.";

        public static Result<object> ValidateIdGetConverted<T>(string id)
        {
            return ValidateIdGetConverted(typeof(T), id);
        }

        public static Result<object> ValidateIdGetConverted(Type type, string id)
        {
            if (id is null)
            {
                return new Result<object>(new ValidationException(CANNOT_BE_NULL));
            }

            var tryParseMethodtype = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, [typeof(string), type.MakeByRefType()], null);
            var parameters = new object[] { id, null! };

            if (tryParseMethodtype is not null 
                && (bool)tryParseMethodtype.Invoke(null, parameters)!)
            {
                return parameters[1];
            }
            else
            {
                return new Result<object>(new ValidationException(NEED_TO_BE_A_GUID));
            }
        }
    }
}
