namespace CarDealer.ImportDto
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("partId")]
    public class PartIdImportDto
    {        
        [XmlAttribute("id")]
        public int Id { get; set; }      
    }
}
