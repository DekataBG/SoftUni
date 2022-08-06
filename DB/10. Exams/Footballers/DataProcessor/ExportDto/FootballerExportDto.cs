using Footballers.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Footballer")]
    public class FootballerExportDto
    {
        [XmlElement("Name")]
        public string Name { get; set; }


        [XmlElement("Position")]
        public string Position { get; set; }

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
