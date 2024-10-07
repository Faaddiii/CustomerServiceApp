using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CustomerServiceApp.Utilities
{
    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Check if user is authenticated
            if (string.IsNullOrEmpty(ClientSession.Username) || ClientSession.ID == 0)
            {
                // Redirect to the login page if the session is not valid
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            base.OnActionExecuting(context);
        }
    }

}
