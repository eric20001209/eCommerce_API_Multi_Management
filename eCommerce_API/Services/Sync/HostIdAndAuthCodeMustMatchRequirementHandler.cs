using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using eCommerce_API_RST_Multi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using System.Text;

namespace eCommerce_API_RST_Multi.Services.Sync
{
    public class HostIdAndAuthCodeMustMatchRequirementHandler: AuthorizationHandler<HostIdAndAuthCodeMustMatchRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly HostDbContext _context;
        public HostIdAndAuthCodeMustMatchRequirementHandler(IHttpContextAccessor httpContextAccessor, HostDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HostIdAndAuthCodeMustMatchRequirement requirement)
        {
            var hostUser = _context.HostTenants.Select(h => new { h.Id, h.AuthCode }).ToDictionary(c => c.Id.ToString(), c => c.AuthCode.ToString());

            var hostId = _httpContextAccessor.HttpContext.GetRouteValue("hostId").ToString();
            var authCode = _httpContextAccessor.HttpContext.GetRouteValue("auth").ToString();
            var hostIdAndauthCodePair = new KeyValuePair<string, string>(hostId, authCode);

            /*  if hostTenant database contains this keyvalue pair, then pass   */
            if (hostUser.Contains(hostIdAndauthCodePair))
                context.Succeed(requirement);
            else
            {
                string authorizeResult = "fail HostIdAndAuthCodeMatch, please contact your administrator.";
                byte[] bytes;
                var httpContext = _httpContextAccessor.HttpContext;
                bytes = Encoding.UTF8.GetBytes(authorizeResult);
                httpContext.Response.StatusCode = 405;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);
            }

            return Task.CompletedTask;
        }
    }
}
