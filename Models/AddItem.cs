using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Models
{
    public class AddItem
    {
        public string ItemName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}