using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MaxioAdvancedBilling;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddMaxioAdvancedBillingClient(Action<MaxioAdvancedBillingClientOptions>? configure = null)
        {
            var options = new MaxioAdvancedBillingClientOptions();
            configure?.Invoke(options);
            services.AddHttpClient();
            services.AddTransient(sp =>
                {
                    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                    var httpClient = httpClientFactory.CreateClient();
                    return new MaxioAdvancedBillingClient(httpClient, options);
                });
            return services;
        }
    }
}
