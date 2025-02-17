

namespace Order.Dtos
{
    public class ResponseDto
    {
        [JsonPropertyName("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonPropertyName("result")]
        public object? Result { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}
