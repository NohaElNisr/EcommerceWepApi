using SouqAPI.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SouqAPI.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        //[ForeignKey("category")]
        //public int Category_ID { get; set; }

        //[JsonIgnore]
        //public virtual Category category { get; set; }
    }
}
