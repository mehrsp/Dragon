using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rosentis.Site.Models
{
    public class ProductFilterModel
    {
        public decimal PriceMin { get; set; }
        public decimal CurrentMinValue { get; set; }
        public decimal PriceMax { get; set; }
        public decimal CurrentMaxValue { get; set; }
        public string Color { get; set; }
    }
}