
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == Data.Models.Enums.GunType.AntiAircraftGun)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        }).OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new GunExportDto
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                        .Where(cg => cg.Country.ArmySize > 4_500_000)
                        .Select(cg => new CountryExportDto
                        {
                            Country = cg.Country.CountryName,
                            ArmySize = cg.Country.ArmySize
                        }).OrderBy(c => c.ArmySize)
                        .ToArray()
                }).OrderBy(g => g.BarrelLength)
                .ToArray();

            return Serialize<GunExportDto[]>("Guns", guns);
        }

        private static string Serialize<T>(string rootName, T dtoArray)
        {
            var root = new XmlRootAttribute(rootName);

            var serializer = new XmlSerializer(typeof(T), root);

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            using var writer = new StringWriter();

            serializer.Serialize(writer, dtoArray, namespaces);

            return writer.ToString();
        }
    }
}
