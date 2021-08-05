using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pcoint.Models
{
    public class YourProducts
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

        [Display(Name = "UserId")]
        public int UserId { get; set; }
    }
}
