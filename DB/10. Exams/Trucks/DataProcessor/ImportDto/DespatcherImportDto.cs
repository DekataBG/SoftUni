namespace Trucks.DataProcessor.ImportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Despatcher")]
    public class DespatcherImportDto
    {
        [Required]
        [XmlElement("Name")]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        public TruckImportDto[] Trucks { get; set; }
    }
}

//Despatcher
//⦁	Id – integer, Primary Key
//⦁	Name – text with length [2, 40] (required)
//⦁	Position – text



