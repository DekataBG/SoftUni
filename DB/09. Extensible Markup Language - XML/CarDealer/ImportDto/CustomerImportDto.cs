namespace CarDealer.ImportDto
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Customer")]
    public class CustomerImportDto
    {        
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
