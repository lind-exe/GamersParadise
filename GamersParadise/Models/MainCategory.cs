using System.Text.Json.Serialization;

namespace GamersParadise.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("subCategories")]
        public List<SubCategory>? SubCategories { get; set; }
    }
}
