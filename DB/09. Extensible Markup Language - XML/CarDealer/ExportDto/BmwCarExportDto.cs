namespace CarDealer.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("car")]
    public class BmwCarExportDto
    {        
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
