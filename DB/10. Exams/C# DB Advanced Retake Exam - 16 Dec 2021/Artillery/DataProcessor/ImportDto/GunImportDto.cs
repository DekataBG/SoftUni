namespace Artillery.DataProcessor.ImportDto
{
    using Artillery.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GunImportDto
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(100, 1_350_000)]
        public int GunWeight { get; set; }

        [Required]
        [Range(2.00, 35.00)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Required]
        [Range(1, 100_000)]
        public int Range { get; set; }

        [Required]
        [EnumDataType(typeof(GunType))]
        public string GunType { get; set; }

        [Required]
        public int ShellId { get; set; }

        public CountryIdImportDto[] Countries { get; set; }
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

//"ManufacturerId": 14,
//    "GunWeight": 531616,
//    "BarrelLength": 6.86,
//    "NumberBuild": 287,
//    "Range": 120000,
//    "GunType": "Howitzer",
//    "ShellId": 41,
//    "Countries": [
//      { "Id": 86 },
//      { "Id": 57 },
//      { "Id": 64 },
//      { "Id": 74 },
