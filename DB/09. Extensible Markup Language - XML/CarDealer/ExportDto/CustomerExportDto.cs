namespace CarDealer.ExportDto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class CustomerExportDto
    {        
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public int SalesCount { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
