namespace CarDealer.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarExportDto
    {        
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
