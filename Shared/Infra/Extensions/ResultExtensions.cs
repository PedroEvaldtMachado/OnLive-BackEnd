using LanguageExt.Common;

namespace Shared.Infra.Extensions
{
    public static class ResultExtensions
    {
        public static TValue GetValue<TValue>(this Result<TValue> result) => result.Match(Succ: value => value, Fail: _ => default!);

        public static TValue GetValueOrDefault<TValue>(this Result<TValue> result, TValue defaultValue) => result.Match(Succ: value => value, Fail: _ => defaultValue);

        public static Result<TNewResult> NewWithException<TFromResult, TNewResult>(this Result<TFromResult> result)
        {
            if (result.IsFaulted)
            {
                return new Result<TNewResult>(result.GetException());
            }

            return new Result<TNewResult>();
        }

        public static Exception GetException<TResult>(this Result<TResult> result)
        {
            return result.Match(Succ: _ => null!, Fail: err => err);
        }
    }
}
