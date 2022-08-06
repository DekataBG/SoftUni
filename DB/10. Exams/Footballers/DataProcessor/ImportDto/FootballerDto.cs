using Footballers.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerDto
    {
        [XmlElement("Name")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("ContractStartDate")]
        [Required(AllowEmptyStrings = false)]
        public string ContractStartDate { get; set; }

        [XmlElement("ContractEndDate")]
        [Required(AllowEmptyStrings = false)]
        
        public string ContractEndDate { get; set; }

        [XmlElement("PositionType")]
        [Required(AllowEmptyStrings = false)]
        [EnumDataType(typeof(PositionType))]
        public string PositionType { get; set; }

        [XmlElement("BestSkillType")]
        [Required(AllowEmptyStrings = false)]
        [EnumDataType(typeof(BestSkillType))]
        public string BestSkillType { get; set; }
    }
}

//⦁	Name – text with length [2, 40] (required)
//⦁	ContractStartDate – date and time (required)
//⦁	ContractEndDate – date and time (required)
//⦁	PositionType – enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required)
//⦁	BestSkillType – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required)
//⦁	CoachId – integer, foreign key(required)
//⦁	Coach – Coach 
//⦁	TeamsFootballers – collection of type TeamFootballer
