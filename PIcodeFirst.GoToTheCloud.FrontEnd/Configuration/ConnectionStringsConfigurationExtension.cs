using Microsoft.Extensions.Configuration;
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
    }
}
