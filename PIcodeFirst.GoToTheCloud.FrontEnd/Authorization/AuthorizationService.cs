using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Authorization
{
    public class AuthorizationService
    {
        private readonly AzureAdGroupsOptions _options;

        public AuthorizationService(IOptions<AzureAdGroupsOptions> options)
        {
            _options = options.Value;
        }

        public bool CheckIfUserIsAdministrator(ClaimsPrincipal user)
        {
            var groups = user.Claims.Where(c => c.Type == "groups").ToList();

            return groups.Any(g => g.Value == _options.AppAdministratorGroupId);
        }
    }
}
