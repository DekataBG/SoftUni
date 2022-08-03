using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductsShop.Data.Models
{
    public class Product
    {
        public Product()
        {
            Categories = new HashSet<CategoryProducts>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Buyer))]
        public int BuyerId { get; set; }

        public User Buyer { get; set; }

        [Required]
        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        public User Seller { get; set; }

        public ICollection<CategoryProducts> Categories { get; set; }
    }
}
