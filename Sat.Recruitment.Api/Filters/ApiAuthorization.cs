using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Sat.Recruitment.Api.Configurations;

namespace Sat.Recruitment.Api.Filters;

public class ApiAuthorization : Attribute, IAuthorizationFilter
{
    private const string BEARER_API_KEY_FORMAT = "Bearer {0}";

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!APIKeyIsValid(context))
        {
            context.Result = new JsonResult("NotAuthorized")
            {
                Value = "Invalid API Key"
            };
            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
        }
    }

    private static string GetTokenFromHeader(AuthorizationFilterContext context)
    {
        return context.HttpContext.Request.Headers[HttpRequestHeader.Authorization.ToString()].ToString();
    }

    private static bool APIKeyIsValid(AuthorizationFilterContext context)
    {
        var apiKeyFromHeader = GetTokenFromHeader(context);

        if (string.IsNullOrWhiteSpace(apiKeyFromHeader))
            return false;

        var optionToken =
            (IOptions<AuthTokenOptions>) context.HttpContext.RequestServices.GetService(
                typeof(IOptions<AuthTokenOptions>));

        return apiKeyFromHeader == string.Format(BEARER_API_KEY_FORMAT, optionToken.Value.Token);
    }
}