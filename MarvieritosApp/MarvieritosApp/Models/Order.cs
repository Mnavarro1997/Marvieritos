using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvieritosApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        [JsonIgnore]
        public ICollection<Product> Product { get; set; }
    }
}