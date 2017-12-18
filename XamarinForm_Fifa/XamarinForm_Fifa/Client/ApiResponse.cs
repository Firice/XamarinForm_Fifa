
using Newtonsoft.Json;

namespace XamarinForm_Fifa.Client
{
    public class ApiResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
