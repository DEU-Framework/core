using System.Security.Claims;
using DEU_Backend.Services;
using DEU_Lib.Model;
using DEU_Lib.Model.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DEU_Backend.Filters
{
    public class DepartmentAuthorizeFilter(DepartmentAuthorizationService deptAuthService, UserManager<ApplicationUser> userManager) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userId = userManager.GetUserId(context.HttpContext.User);
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (context.ActionArguments.TryGetValue("departmentId", out var value) && value is int departmentId)
            {
                if (await deptAuthService.IsUserAuthorizedForDepartmentAsync(userId, departmentId))
                {
                    await next();
                    return;
                }
            }

            context.Result = new ForbidResult();
        }
    }
}