namespace CarDealer.ExportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class SaleExportDto
    {        
        [XmlElement("car")]
        public CarWithPartsExportDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
