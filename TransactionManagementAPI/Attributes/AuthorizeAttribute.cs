using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TransactionManagementAPI.Services.Interfaces;

namespace TransactionManagementAPI.Attributes;

// Custom attribute to enforce user authentication on controllers or actions
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userService = context.HttpContext.RequestServices.GetService<IUserService>();

        // Implement a simple authentication check
        if (!userService.ValidateUser("admin", "password"))
        {
            // If validation fails, set the result as unauthorized
            context.Result = new UnauthorizedResult();
        }
    }
}