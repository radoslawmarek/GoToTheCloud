using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Authentication
{
    public static class AzureAdAuthenticationBuilder
    {
        public static AuthenticationBuilder AddAzureAdAuthentication(this AuthenticationBuilder builder)
        {
            return builder.AddAzureAdAuthentication(_ => { });
        }

        public static AuthenticationBuilder AddAzureAdAuthentication(this AuthenticationBuilder builder, Action<AzureAdOptions> options)
        {
            builder.Services.Configure(options);
            builder.Services.AddSingleton<IConfigureOptions<OpenIdConnectOptions>, ConfigureAzureOptions>();
            builder.AddOpenIdConnect();

            return builder;
        }

    }
}
