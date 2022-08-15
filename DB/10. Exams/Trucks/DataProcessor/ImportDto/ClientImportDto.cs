namespace Trucks.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Trucks.Data.Models.Enums;

    [XmlType("Client")]
    public class ClientImportDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Nationality")]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlArray("Trucks")]
        public int[] Trucks { get; set; }
    }
}

//⦁	Name – text with length [3, 40] (required)
//⦁	Nationality – text with length [2, 40] (required)
//⦁	Type – text(required)
//⦁	Trucks – collection of ids


