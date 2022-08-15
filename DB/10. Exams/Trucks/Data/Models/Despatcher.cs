namespace Trucks.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Despatcher
    {
        public Despatcher()
        {
            Trucks = new HashSet<Truck>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}

//Despatcher
//⦁	Id – integer, Primary Key
//⦁	Name – text with length [2, 40] (required)
//⦁	Position – text
//⦁	Trucks – collection of type Truck



