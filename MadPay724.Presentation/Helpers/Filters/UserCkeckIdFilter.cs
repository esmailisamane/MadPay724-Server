using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Claims;


namespace MadPay724.Presentation.Helpers.Filters
{
    public class UserCkeckIdFilter:ActionFilterAttribute 
    {
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _httpContextAcc;
        public UserCkeckIdFilter(ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAcc)
        {
            _logger = loggerFactory.CreateLogger("UserCkeckIdFilter");
            _httpContextAcc = httpContextAcc;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.RouteData.Values["id"].ToString() == _httpContextAcc.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                base.OnActionExecuting(context);
            }
            else
            {
                _logger.LogError($"درخواست غیرمجاز از کاربر {context.RouteData.Values["id"].ToString()}");
                context.Result = new UnauthorizedResult();
            }

           
        }
    }
}
