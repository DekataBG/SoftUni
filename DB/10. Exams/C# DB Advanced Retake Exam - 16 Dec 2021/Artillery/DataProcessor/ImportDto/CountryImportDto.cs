namespace Artillery.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Country")]
    public class CountryImportDto
    {
        [Required]
        [StringLength(60, MinimumLength = 4)]
        [XmlElement("CountryName")]
        public string CountryName { get; set; }

        [Required]
        [Range(50_000, 10_000_000)]
        [XmlElement("ArmySize")]
        public int ArmySize { get; set; }
    }
}

//Country
//⦁	Id – integer, Primary Key
//⦁	CountryName – text with length [4, 60] (required)
//⦁	ArmySize – integer in the range[50_000….10_000_000] (required)
//⦁	CountriesGuns – a collection of CountryGun
