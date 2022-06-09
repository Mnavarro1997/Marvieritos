using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvieritosApp.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        [JsonIgnore]
        public Product Product { get; set; }
        public Order Order { get; set; }
        public string ProductName => Product?.Name;

        // ? sea nullable, que no falle.
        public decimal? Price => Product?.Price;

        public decimal? Total => Product?.Price * Quantity;
    }
}
