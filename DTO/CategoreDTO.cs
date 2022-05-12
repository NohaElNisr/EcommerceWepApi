using System.Collections.Generic;

namespace SouqAPI.DTO
{
    public class CategoreDTO
    {
        public int catid { get; set; }
        public string catname { get; set; }
        public List<ProductDTO> product { get; set; } = new List<ProductDTO>();



    }
}
