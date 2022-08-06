using Footballers.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class CoachExportDto
    {
        [XmlElement("CoachName")]
        [XmlAttribute("Name")]
        public string CoachName { get; set; }
        
        [XmlArray("Footballers")]
        public FootballerExportDto[] Footballers { get; set; }

        public int Count { get; set; }
    }
}

//⦁	Name – text with length [2, 40] (required)
//⦁	Nationality – text(required)
//⦁	Footballers – collection of type Footballer