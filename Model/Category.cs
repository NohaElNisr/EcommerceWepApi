using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SouqAPI.Model
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Product { get; set; }
    }
}
