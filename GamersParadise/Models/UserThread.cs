using System.Text.Json.Serialization;

namespace GamersParadise.Models
{
    public class UserThread
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("authorId")]
        public string UserId { get; set; }
        [JsonPropertyName("header")]
        public string Header { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("imageURL")]

        public string? ImageURL { get; set; }
        [JsonPropertyName("comments")]
        public List<Comment> Comments { get; set; }
    }
}
