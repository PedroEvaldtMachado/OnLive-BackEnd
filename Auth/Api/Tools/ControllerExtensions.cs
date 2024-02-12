using LanguageExt.Common;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using LanguageExt;

namespace Api.Tools
{
    public static class ControllerExtensions
    {
        public static IActionResult ApiResult<TResult, TContract>(this Result<TResult> result, Func<TResult, TContract> func)
        {
            return result.Match<IActionResult>(
                Succ: value =>
                {
                    if (value is Unit)
                    {
                        return new OkResult();
                    }
                    else
                    {
                        return new OkObjectResult(func(value));
                    }
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
