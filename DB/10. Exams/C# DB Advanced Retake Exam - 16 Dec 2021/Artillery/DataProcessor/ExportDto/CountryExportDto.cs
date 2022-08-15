namespace Artillery.DataProcessor.ExportDto
{
    using Artillery.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class CountryExportDto
    {
        [XmlAttribute("Country")]
        public string Country { get; set; }

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
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
