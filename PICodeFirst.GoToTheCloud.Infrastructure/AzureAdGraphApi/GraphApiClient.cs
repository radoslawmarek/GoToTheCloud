using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi.GraphApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi
{
    public class GraphApiClient
    {
        private string _clientId = "747c1ed6-f45b-4e12-80e2-bd3d32e00eb0";
        private string _clientSecret = "7e+nA5Z5EkMbhZRxU2CAlULu2VABm1QISOQfXAT/Vg8=";
        private string _organizationId = "ea817d65-4bbd-4d79-a882-eff2c5ffe530";

        private AuthenticationContext _authContext = null;
        private ClientCredential _clientCredential = null;

        public GraphApiClient(string organizationId, string clientId, string clientSecret)
        {
            _organizationId = organizationId;
            _clientId = clientId;
            _clientSecret = clientSecret;

            _authContext = new AuthenticationContext("https://login.microsoftonline.com/" + _organizationId);
            _clientCredential = new ClientCredential(clientId, clientSecret);
        }

        public async Task<string> SendRequest(string api, string query)
        {
            var graphApiVersion = "api-version=1.6";

            AuthenticationResult authResult = await _authContext.AcquireTokenAsync("https://graph.windows.net", _clientCredential);

            HttpClient http = new HttpClient();
            string url = $"https://graph.windows.net/{_organizationId}/{api}?{graphApiVersion}"
                + (string.IsNullOrEmpty(query) ? string.Empty : $"&{query}");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            HttpResponseMessage response = await http.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                object formatted = JsonConvert.DeserializeObject(error);
                throw new WebException("Error Calling the Graph API: \n" + JsonConvert.SerializeObject(formatted, Formatting.Indented));
            }

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<IEnumerable<GraphGroup>> GetAllGroups()
        {
            var jsonResponse = await SendRequest("groups", string.Empty);

            var groupList = JsonConvert.DeserializeObject<GraphGroupList>(jsonResponse);
            return groupList.Groups;
        }
    }
}
