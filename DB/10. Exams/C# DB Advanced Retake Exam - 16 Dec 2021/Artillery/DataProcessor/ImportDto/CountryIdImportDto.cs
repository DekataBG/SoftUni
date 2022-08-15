namespace Artillery.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    public class CountryIdImportDto
    {
        [Required]
        public int Id { get; set; }

    }
}

//Country
//⦁	Id – integer, Primary Key
//⦁	CountryName – text with length [4, 60] (required)
//⦁	ArmySize – integer in the range[50_000….10_000_000] (required)
//⦁	CountriesGuns – a collection of CountryGun
