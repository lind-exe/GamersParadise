using System.Text.Json.Serialization;

namespace GamersParadise.Models
{
    public class SubCategory
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("userThreads")]
        public List<UserThread>? UserThreads { get; set; }

    }

}
