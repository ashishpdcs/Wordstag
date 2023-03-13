using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Wordstag.API.Infrastructure.Models;
using Wordstag.Utility;

namespace Wordstag.API.Infrastructure.Filters
{
    public class ActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
                return;

            if (context.Result.GetType() == typeof(FileContentResult))
                return;

            var result = context.Result;
            var responseObj = new ResponseModel
            {
                Message = string.Empty,
                StatusCode = 200,
                Errors = null,
            };

            switch (result)
            {
                case OkObjectResult okresult:
                    responseObj.Data = okresult.Value;
                    break;
                case ObjectResult objectResult:
                    var data = (Dictionary<string, object>)(objectResult.Value);
                    responseObj.Message = data.ContainsKey(Constants.ResponseMessageField) ? Convert.ToString(data[Constants.ResponseMessageField]) : null;
                    responseObj.Data = data.ContainsKey(Constants.ResponseDataField) ? data[Constants.ResponseDataField] : null;
                    break;
                case JsonResult json:
                    responseObj.Data = json.Value;
                    break;
                case OkResult _:
                case EmptyResult _:
                    responseObj.Data = null;
                    break;
                default:
                    responseObj.Data = result;
                    break;
            }
            //var rtnResult = new JsonResult(responseObj);

            context.Result = new JsonResult(responseObj);
        }
    }
}
