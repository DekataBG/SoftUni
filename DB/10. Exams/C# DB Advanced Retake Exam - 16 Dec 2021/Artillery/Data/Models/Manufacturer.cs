namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public Manufacturer()
        {
            Guns = new HashSet<Gun>();
        }

        public int Id { get; set; }

        [Required]
        public string ManufacturerName { get; set; }

        [Required]
        public string Founded { get; set; }

        public ICollection<Gun> Guns { get; set; }
    }
}

//Manufacturer
//⦁	Id – integer, Primary Key
//⦁	ManufacturerName – unique text with length [4…40] (required)
//⦁	Founded – text with length [10…100] (required)
//⦁	Guns – a collection of Gun
