using Footballers.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Coach")]
    public class CoachDto
    {
        [XmlElement("Name")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("Nationality")]
        [Required(AllowEmptyStrings = false)]
        public string Nationality { get; set; }

        [XmlArray("Footballers")]
        public FootballerDto[] Footballers { get; set; }
    }
}

//⦁	Name – text with length [2, 40] (required)
//⦁	Nationality – text(required)
//⦁	Footballers – collection of type Footballer