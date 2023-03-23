using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab1.Filters
{
    //inherits from "Attribute" also because DisabledV1Attribute should be an attribute class
    public class DisabledV1Attribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // We check if v1 is present in the request Path
            if (context.HttpContext.Request.Path.Value!.ToUpper().Contains("V1"))
            {
                // We create a Bad Request Result
                context.Result = new BadRequestObjectResult
                (
                    new GeneralResponse("This version is Expired, switch to /api/Cars/v2")
                );
            }
        }
        public void OnResourceExecuted(ResourceExecutedContext context){ } //IResourceFilter gives error because OnResourceExecuted Should be implemented
    }
}
