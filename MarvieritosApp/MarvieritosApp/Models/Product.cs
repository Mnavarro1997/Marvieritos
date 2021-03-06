using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarvieritosApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UrlImg { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public ICollection<Category> Category { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}