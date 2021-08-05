using System.ComponentModel.DataAnnotations;

namespace Pcoint.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Display(Name = "LaptopModel")]
        public string LaptopModel { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }
        
        [Display(Name = "Size")]
        public string Size { get; set; }
        
        [Display(Name = "Price")]
        public string Price { get; set; }
    }
}
