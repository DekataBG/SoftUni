namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var footballersToImport = new List<Footballer>();

            var coaches = XmlConverter.Deserializer<CoachDto>(xmlString, "Coaches");

            foreach (var coachDto in coaches)
            {
                var footballers = new List<FootballerDto>();

                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var coachToImport = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };
                context.Coaches.Add(coachToImport);
                context.SaveChanges();

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto) || DateTime.Compare(
                            DateTime.ParseExact(footballerDto.ContractStartDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                            DateTime.ParseExact(footballerDto.ContractEndDate, "dd/mm/yyyy", CultureInfo.InvariantCulture)) >= 0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    

                    footballers.Add(footballerDto);
                    var footballerToImport = new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = DateTime.ParseExact(footballerDto.ContractStartDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                        ContractEndDate = DateTime.ParseExact(footballerDto.ContractEndDate, "dd/mm/yyyy", CultureInfo.InvariantCulture),
                        PositionType = (PositionType)Enum.Parse(typeof(PositionType), footballerDto.PositionType),
                        BestSkillType = (BestSkillType)Enum.Parse(typeof(BestSkillType), footballerDto.BestSkillType),
                        CoachId = context.Coaches.FirstOrDefault(c => c.Name == coachDto.Name).Id,
                        Coach = context.Coaches.FirstOrDefault(c => c.Name == coachDto.Name)
                    };
                    context.Footballers.Add(footballerToImport);
                    coachToImport.Footballers.Add(footballerToImport);
                    context.Coaches.Update(coachToImport);
                    context.SaveChanges();
                }

                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coachDto.Name, footballers.Count));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var teams = JsonConvert.DeserializeObject<TeamDto[]>(jsonString);

            foreach (var teamDto in teams)
            {
                var footballers = new List<Footballer>();

                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var team = new Team
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies,
                };

                context.Teams.Add(team);
                context.SaveChanges();

                foreach (var id in teamDto.Footballers)
                {
                    if(!context.Footballers.Select(f => f.Id).Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var footballer = context.Footballers.Find(id);
                    footballers.Add(footballer);

                    var teamFootballer = new TeamFootballer
                    {
                        TeamId = id,
                        Team = context.Teams.FirstOrDefault(t => t.Name == teamDto.Name),
                        FootballerId = id,
                        Footballer = context.Footballers.Find(id)
                    };

                    context.TeamsFootballers.Add(teamFootballer);
                    context.SaveChanges();

                    footballer.TeamsFootballers.Add(teamFootballer);
                    team.TeamsFootballers.Add(teamFootballer);

                    context.Footballers.Update(footballer);
                    context.Teams.Update(team);
                    context.SaveChanges();
                }

                sb.AppendLine(String.Format(SuccessfullyImportedTeam, teamDto.Name, footballers.Count));
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
