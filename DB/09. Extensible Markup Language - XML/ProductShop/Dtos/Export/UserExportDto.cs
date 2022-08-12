﻿namespace ProductShop.Dtos.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class UserExportDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlArray("soldProducts")]
        public ProductExportDto[] SoldProducts { get; set; }

        [XmlElement("SoldProducts")]
        public ProductsExportDto SoldProductsWithCount { get; set; }
    }
}