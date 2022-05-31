using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarvieritosApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [JsonIgnore]
        public IEnumerable<Product> Products { get; set; }
    }
}
