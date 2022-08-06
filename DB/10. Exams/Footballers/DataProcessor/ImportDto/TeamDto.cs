using Footballers.Data.Models.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamDto
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[A-z0-9\s.-]+$")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(1, int.MaxValue)]
        public int Trophies { get; set; }

        public HashSet<int> Footballers { get; set; }
    }
}

//⦁	Id – integer, Primary Key
//⦁	Name – text with length [3, 40]. May contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
//⦁	Nationality – text with length [2, 40] (required)
//⦁	Trophies – integer(required)
//⦁	TeamsFootballers – collection of type TeamFootballer