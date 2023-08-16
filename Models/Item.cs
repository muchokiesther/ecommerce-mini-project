using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class Item
    {
        public string Id { get; set; }  = string.Empty;
        public string ItemName { get; set; }  = string.Empty;

        public string Description { get; set; }  = string.Empty;
        public string  Price { get; set; }  = string.Empty;
        
    }
}