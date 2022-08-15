namespace Artillery.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Manufacturer")]
    public class ManufacturerImportDto
    {
        [Required]
        [StringLength(40, MinimumLength = 4)]
        [XmlElement("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [XmlElement("Founded")]
        public string Founded { get; set; }
    }
}

//Manufacturer
//⦁	Id – integer, Primary Key
//⦁	ManufacturerName – unique text with length [4…40] (required)
//⦁	Founded – text with length [10…100] (required)
//⦁	Guns – a collection of Gun

