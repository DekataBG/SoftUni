namespace Trucks.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using Trucks.DataProcessor.ExportDto;

    [XmlType("Despatcher")]
    public class DespatcherExportDto
    {
        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; }

        [XmlArray("Trucks")]
        public TruckExportDto[] Trucks { get; set; }
    }
}

//Despatcher
//⦁	Id – integer, Primary Key
//⦁	Name – text with length [2, 40] (required)
//⦁	Position – text



