using PICodeFirst.GoToTheCloud.App.consts;
using PICodeFirst.GoToTheCloud.App.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.Authorization
{
    public static class ClaimsPrincipalExtensions
    {
        private static AzureAdGroupsOptions _options;

        public static Guid GetApplicationAdminGroupId()
        {
            if (_options == null || string.IsNullOrEmpty(_options.AppAdministratorGroupId))
            {
                return Guid.Empty;
            }

            return Guid.Parse(_options.AppAdministratorGroupId);
        }

        public static User CreateUser(this ClaimsPrincipal claimsPrincipal)
        {
            var userGroups = new List<Group>();
            var user = ((ClaimsIdentity)claimsPrincipal.Identity);
            var claims = user.Claims;
            var firstName = claims.FirstOrDefault(c => c.Type.EndsWith("givenname"))?.Value ?? string.Empty;
            var lastName = claims.FirstOrDefault(c => c.Type.EndsWith("surname"))?.Value ?? string.Empty;
            var id = claims.FirstOrDefault(c => c.Type.EndsWith("objectidentifier"))?.Value ?? string.Empty;

            var groupGuids = claims.Where(c => c.Type == "groups").ToList();
            if (groupGuids != null)
            {
                foreach(var g in groupGuids)
                {
                    if (g.Value == _options.AppAdministratorGroupId)
                    {
                        userGroups.Add(new Group() { Name = AuthorizationConsts.ApplicationAdministratorGroupName });
                    }
                    else
                    {
                        userGroups.Add(new Group() { Name = AuthorizationConsts.UserGroupName });
                    }
                }
            }

            var result =  new User(Guid.Parse(id))
            {
                Name = user.Name,
                FirstName = firstName,
                LastName = lastName,
            };

            foreach(var g in userGroups)
            {
                result.AddGroup(g);
            }

            return result;
        }

        public static void SetAzureAdGroupOptions(AzureAdGroupsOptions options)
        {
            _options = options;
        }
    }
}
