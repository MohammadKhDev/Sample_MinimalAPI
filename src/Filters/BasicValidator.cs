using FluentValidation;
using Sample_MinimalAPI.Models;
using System.Net;

namespace Sample_MinimalAPI.Filters
{
    public class BasicValidator<T> : IEndpointFilter where T : class
    {
        private IValidator<T> _validator;
        public BasicValidator(IValidator<T> validator)
        {
            _validator = validator;
        }

        public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest };
            var contextObj = context.Arguments.SingleOrDefault(x => x?.GetType() == typeof(T));

            if (contextObj == null)
            {
                return Results.BadRequest(response);
            }
            var result = await _validator.ValidateAsync((T)contextObj);
            if (!result.IsValid)
            {
                response.ErrorMessages.Add(result.Errors.FirstOrDefault().ToString());
                return Results.BadRequest(response);
            }
            return await next(context);
        }
    }
}
