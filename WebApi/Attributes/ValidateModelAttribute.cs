using Application.DTOs;
using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace WebApi.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(m => m.Value.Errors)
                                                .Select(m => m.ErrorMessage)
                                                .ToList();
                context.Result = new BadRequestObjectResult(new InvalidResponse<ErrorResponse>(errors.ToArray()));
            }
        }
    }
}
