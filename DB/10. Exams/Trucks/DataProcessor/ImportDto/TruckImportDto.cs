namespace Trucks.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;

    [XmlType("Truck")]
    public class TruckImportDto
    {
        [Required]
        [XmlElement("RegistrationNumber")]
        [StringLength(8, MinimumLength = 8)]
        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string RegistrationNumber { get; set; }

        [Required]
        [XmlElement("VinNumber")]
        [StringLength(17, MinimumLength = 17)]
        public string VinNumber { get; set; }

        [Required]
        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [Required]
        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [EnumDataType(typeof(CategoryType))]
        public string CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        [EnumDataType(typeof(MakeType))]
        public string MakeType { get; set; }
    }
}

//Truck
//⦁	RegistrationNumber – text with length 8. First two characters are upper letters [A-Z],
//followed by four digits and the last two characters are upper letters [A-Z] again.
//⦁	VinNumber – text with length 17 (required)
//⦁	TankCapacity – integer in range[950…1420]
//⦁	CargoCapacity – integer in range[5000…29000]
//⦁	CategoryType – enumeration of type CategoryType, with possible values (Flatbed, Jumbo, Refrigerated, Semi) (required)
//⦁	MakeType – enumeration of type MakeType, with possible values (Daf, Man, Mercedes, Scania, Volvo) (required)




