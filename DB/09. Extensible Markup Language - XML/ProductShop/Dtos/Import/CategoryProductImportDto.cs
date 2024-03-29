﻿namespace ProductShop.Dtos.Import
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("CategoryProduct")]
    public class CategoryProductImportDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}