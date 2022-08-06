namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .Where(c => c.Footballers.Count > 0)
                .Select(c => new CoachExportDto
                {
                    Count = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers.Select(f => new FootballerExportDto
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    }).OrderBy(f => f.Name)
                    .ToArray()
                })
                .OrderByDescending(c => c.Count)
                .ToList();


            var xml = XmlConverter.Serialize(coaches, "Coaches");

            return xml;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Where(t => t.TeamsFootballers
                    .Select(tf => tf.Footballer)
                    .Any(f => f.ContractStartDate >= date))
                .Select(t => new
                {
                    Name = t.Name,
                    Footballers = t.TeamsFootballers.Select(tf => tf.Footballer).Where(f => f.ContractStartDate >= date)
                    .Select(f => new
                    {
                        FootballerName = f.Name,
                        ContractStartDate = f.ContractStartDate,
                        //ContractEndDate = DateTime.ParseExact(f.ContractEndDate.ToString(), "mm/dd/yyyy", CultureInfo.InvariantCulture),
                        ContractEndDate =f.ContractEndDate,
                        BestSkillType = f.BestSkillType,
                        PositionType = f.PositionType
                    })
                    .OrderByDescending(f => f.ContractEndDate)
                    .ThenBy(f => f.FootballerName)
                    .ToList()
                }).ToList()
                .OrderByDescending(t => t.Footballers.Count)
                .ThenBy(t => t.Name)
                .ToList().Take(5);

            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
