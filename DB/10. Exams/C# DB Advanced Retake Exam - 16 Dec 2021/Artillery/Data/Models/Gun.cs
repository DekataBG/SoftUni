namespace Artillery.Data.Models
{
    using Artillery.Data.Models.Enums;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Gun
    {
        public Gun()
        {
            CountriesGuns = new HashSet<CountryGun>();
        }

        public int Id { get; set; }

        [Required]
        public int GunWeight { get; set; }

        [Required]
        public double BarrelLength { get; set; }
        
        public int? NumberBuild { get; set; }

        [Required]
        public int Range { get; set; }

        [Required]
        public GunType GunType { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Required]
        public int ShellId { get; set; }
        public Shell Shell { get; set; }

        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}

//Gun
//⦁	Id – integer, Primary Key
//⦁	GunWeight– integer in range[100…1_350_000](required)
//⦁	BarrelLength – double in range[2.00….35.00](required)
//⦁	NumberBuild – integer
//⦁	Range – integer in range[1….100_000](required)
//⦁	GunType – enumeration of GunType, with possible values (Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
//⦁	ManufacturerId – integer, foreign key (required)
//⦁	ShellId – integer, foreign key(required)
//⦁	CountriesGuns – a collection of CountryGun

