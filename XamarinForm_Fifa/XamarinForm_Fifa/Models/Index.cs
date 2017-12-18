using Newtonsoft.Json;
using System.Collections.Generic;

namespace XamarinForm_Fifa.Models
{
    public class Index
    {
        [JsonProperty("competitions")]
        public List<Competition> Competitions { get; set; }
        [JsonProperty("liveCompetitions")]
        public List<object> LiveCompetitions { get; set; }
        [JsonProperty("live")]
        public List<object> Live { get; set; }
        [JsonProperty("b_QualifiersLive")]
        public bool QualifiersLive { get; set; }
    }
}