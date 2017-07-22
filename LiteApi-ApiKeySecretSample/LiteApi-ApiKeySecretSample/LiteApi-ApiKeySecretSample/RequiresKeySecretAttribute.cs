using LiteApi.Contracts.Abstractions;
using Microsoft.AspNetCore.Http;
using System;

namespace LiteApiApiKeySecretSample.Services
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiresKeySecretAttribute : Attribute, IApiFilter
    {
        public bool IgnoreSkipFilters { get; } = false;

        public ApiFilterRunResult ShouldContinue(HttpContext httpCtx)
        {
            string apiKey = httpCtx.Request.Headers["x-api-key"];
            string apiSecret = httpCtx.Request.Headers["x-api-secret"];
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(apiSecret))
            {
                return ApiFilterRunResult.Unauthenticated;
            }

            IApiKeySecretStore store = httpCtx.RequestServices.GetService(typeof(IApiKeySecretStore)) as IApiKeySecretStore;
            if (!store.ValidateKeySecret(apiKey, apiSecret))
            {
                return ApiFilterRunResult.Unauthenticated;
            }

            return ApiFilterRunResult.Continue;
        }
    }
}
