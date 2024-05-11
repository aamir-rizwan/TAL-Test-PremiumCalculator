using Newtonsoft.Json;

namespace TAL_PremiumCalculatorAPI.Models
{
    public class ApiResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        [JsonProperty("content")]
        public T Content { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string message, T content)
        {
            Success = success;
            Message = message;
            Content = content;
        }
    }
}
