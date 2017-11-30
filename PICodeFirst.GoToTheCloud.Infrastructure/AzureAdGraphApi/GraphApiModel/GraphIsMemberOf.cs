using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.AzureAdGraphApi.GraphApiModel
{
    public class GraphIsMemberOf
    {
        [JsonProperty("odata.metadata")]
        public string Metadata { get; set; }

        [JsonProperty("value")]
        public bool Value { get; set; }
    }
}
