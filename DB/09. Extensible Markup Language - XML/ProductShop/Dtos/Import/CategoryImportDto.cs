namespace ProductShop.Dtos.Import
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class CategoryImportDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}