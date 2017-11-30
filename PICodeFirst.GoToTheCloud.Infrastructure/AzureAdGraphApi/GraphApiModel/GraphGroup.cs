using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi.GraphApiModel
{
    public class GraphGroup
    {
        [JsonProperty("deletionTimestamp")]
        public object DeletionTimestamp { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dirSyncEnabled")]
        public object DirSyncEnabled { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("lastDirSyncTime")]
        public object LastDirSyncTime { get; set; }

        [JsonProperty("mail")]
        public object Mail { get; set; }

        [JsonProperty("mailEnabled")]
        public bool MailEnabled { get; set; }

        [JsonProperty("mailNickname")]
        public string MailNickname { get; set; }

        [JsonProperty("objectId")]
        public string ObjectId { get; set; }

        [JsonProperty("objectType")]
        public string ObjectType { get; set; }

        [JsonProperty("odata.type")]
        public string OdataType { get; set; }

        [JsonProperty("onPremisesDomainName")]
        public object OnPremisesDomainName { get; set; }

        [JsonProperty("onPremisesNetBiosName")]
        public object OnPremisesNetBiosName { get; set; }

        [JsonProperty("onPremisesSamAccountName")]
        public object OnPremisesSamAccountName { get; set; }

        [JsonProperty("onPremisesSecurityIdentifier")]
        public object OnPremisesSecurityIdentifier { get; set; }

        [JsonProperty("provisioningErrors")]
        public List<object> ProvisioningErrors { get; set; }

        [JsonProperty("proxyAddresses")]
        public List<object> ProxyAddresses { get; set; }

        [JsonProperty("securityEnabled")]
        public bool SecurityEnabled { get; set; }
    }
}
