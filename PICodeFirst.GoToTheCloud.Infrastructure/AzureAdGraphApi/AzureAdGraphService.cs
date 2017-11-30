using PICodeFirst.GoToTheCloud.App.Configurations;
using PICodeFirst.GoToTheCloud.App.UserModel;
using PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi.GraphApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi
{
    public class AzureAdGraphService : IUserService
    {
        private readonly UserApiCredentials _azureGraphCredentials = null;

        #region ctor

        public AzureAdGraphService(UserApiCredentials credentials)
        {
            _azureGraphCredentials = credentials;
        }

        #endregion

        public async Task<IEnumerable<Group>> GetAllGroups()
        {
            var result = new List<Group>();

            var client = new GraphApiClient(_azureGraphCredentials.OrganizationId, _azureGraphCredentials.AppId, _azureGraphCredentials.ClientSecret);
            var graphGroups = await client.GetAllGroups();

            foreach(var group in graphGroups)
            {
                result.Add(new Group()
                {
                    Id = Guid.Parse(group.ObjectId),
                    Name = group.DisplayName
                });
            }

            return result;
        }
    }
}
