using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.Tools
{
    public static class ControllerExtensions
    {
        public static IActionResult ApiResult<TResult, TContract>(this Result<TResult> result, Func<TResult, TContract> func)
        {
            return result.Match<IActionResult>(
                Succ: value =>
                {
                    return new OkObjectResult(func(value));
                },
                Fail: err =>
                {
                    if (err is ValidationException validation)
                    {
                        return new BadRequestObjectResult(validation);
                    }

                    return new StatusCodeResult(500);
                });
        }
    }
}
