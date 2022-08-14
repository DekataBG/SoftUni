namespace CarDealer.ImportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Sale")]
    public class SaleImportDto
    {        
        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("discount")]
        public int DIscount { get; set; }
    }
}
