using Lab1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Lab1.Filters
{
    public class ValidateCarTypeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var allowedValues = new Regex
            (
                "^(Electric|Gas|Diesel|Hybrid)$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2)
            );

            Car? car = context.ActionArguments["car"] as Car;

            if (car == null || !allowedValues.IsMatch(car.Type))
            {
                context.Result = new BadRequestObjectResult(new GeneralResponse("The Type is not covered"));
            }
        }
    }
}
