using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductsShop.Data.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<CategoryProducts>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public ICollection<CategoryProducts> Products { get; set; }
    }
}
