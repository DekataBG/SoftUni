using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductsShop.Data.Models
{
    public class User
    {
        public User()
        {
            ProductsSold = new HashSet<Product>();
            ProductsBought = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [InverseProperty(nameof(Product.Seller))]
        public ICollection<Product> ProductsSold { get; set; }

        [InverseProperty(nameof(Product.Buyer))]
        public ICollection<Product> ProductsBought { get; set; }
    }
}
