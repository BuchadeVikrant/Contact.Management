using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using Contacts.Management.Models.ErrorResponses;
using Contacts.Management.Models.Responses;


namespace Contacts.Management.ActionFilters
{
    public class ValidateModel : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                BaseResponse<List<ValidationError>> response = new BaseResponse<List<ValidationError>>();
                response.Errors = GetValidationErrors(actionContext.ModelState);

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        private List<ValidationError> GetValidationErrors(ModelStateDictionary modelState)
        {
            List<ValidationError> errors =
                modelState.Keys
                .SelectMany(key => modelState[key].Errors
                .Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
            return errors;
        }
    }
}