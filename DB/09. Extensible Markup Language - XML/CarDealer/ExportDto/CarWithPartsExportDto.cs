namespace CarDealer.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class CarWithPartsExportDto
    {        
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        [XmlIgnore] //add or remove for different problems
        public PartExportDto[] Parts { get; set; }
    }
}
