namespace Trucks.DataProcessor.ExportDto
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Truck")]
    public class TruckExportDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }

        [XmlElement("Make")]
        public string Make { get; set; }
    }
}

//Despatcher
//⦁	Id – integer, Primary Key
//⦁	Name – text with length [2, 40] (required)
//⦁	Position – text



