using System.Text.Json.Serialization;

namespace MyFirstApi.Models
{
    // Example of C# model class
    public class Product
    {
        [JsonPropertyName("productId")]
        public int Id { get; set; }

        [JsonPropertyName("productName")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
