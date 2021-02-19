using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}