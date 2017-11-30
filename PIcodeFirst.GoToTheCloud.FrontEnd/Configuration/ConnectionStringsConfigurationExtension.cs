using Microsoft.Extensions.Configuration;
using PIcodeFirst.GoToTheCloud.FrontEnd.Authentication;
using PICodeFirst.GoToTheCloud.App.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Configuration
{
    public static class ConnectionStringsConfigurationExtension
    {
        public static ConnectionStrings GetConnectionStrings(this IConfiguration configuration)
        {
            return new ConnectionStrings()
            {
                DefaultConnection = configuration.GetConnectionString("DefaultConnection")
            };
        }

        public static UserApiCredentials GetUserApiCredentials(this IConfiguration configuration)
        {
            var adOptions = new AzureAdOptions();
            configuration.GetSection("AzureAd").Bind(adOptions);

            return new UserApiCredentials()
            {
                AppId = adOptions.ClientId,
                OrganizationId = adOptions.TenantId,
                ClientSecret = adOptions.ClientSecret
            };
        }
    }
}
