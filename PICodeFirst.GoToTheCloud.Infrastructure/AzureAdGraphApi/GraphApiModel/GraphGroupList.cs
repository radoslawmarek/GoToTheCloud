using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi.GraphApiModel
{
    public class GraphGroupList
    {
        [JsonProperty("odata.metadata")]
        public string OdataMetadata { get; set; }

        [JsonProperty("value")]
        public List<GraphGroup> Groups { get; set; }
    }
}
