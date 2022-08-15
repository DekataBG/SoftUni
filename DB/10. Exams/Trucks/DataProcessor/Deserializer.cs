namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.Core.Internal;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var stringBuilder = new StringBuilder();

            var despatchersDto = XmlDeserialize<DespatcherImportDto[]>("Despatchers", xmlString);

            foreach (var despatcherDto in despatchersDto)
            {
                if (!IsValid(despatcherDto) || String.IsNullOrEmpty(despatcherDto.Position))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var despatcher = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    var truck = new Truck
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)Enum.Parse(typeof(CategoryType), truckDto.CategoryType),
                        MakeType = (MakeType)Enum.Parse(typeof(MakeType), truckDto.MakeType)
                    };

                    despatcher.Trucks.Add(truck);
                }

                context.Despatchers.Add(despatcher);
                context.SaveChanges();

                stringBuilder.AppendLine(
                    String.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            return stringBuilder.ToString();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var stringBuilder = new StringBuilder();

           var clientsDto = JsonConvert.DeserializeObject<ClientImportDto[]>(jsonString);

            foreach (var clientDto in clientsDto)
            {
                if (!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }
                
                clientDto.Trucks = clientDto.Trucks
                    .Distinct()
                    .ToArray();

                int countBefore = clientDto.Trucks.Count();
                int countAfter = 0;

                clientDto.Trucks = clientDto.Trucks
                    .Intersect(context.Trucks
                        .Select(t => t.Id))
                    .ToArray();

                countAfter = clientDto.Trucks.Count();

                for (int i = 0; i < countBefore - countAfter; i++)
                {
                    stringBuilder.AppendLine(ErrorMessage);
                }

                var client = new Client
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                    ClientsTrucks = clientDto.Trucks
                        .Select(tId => new ClientTruck
                        {
                            TruckId = tId
                        })
                        .ToArray()
                };

                context.Clients.Add(client);
                context.SaveChanges();

                stringBuilder.AppendLine(
                    String.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            return stringBuilder.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T XmlDeserialize<T>(string rootName, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            using var stringReader = new StringReader(inputXml);

            var objects = (T)serializer.Deserialize(stringReader);

            return objects;
        }
    }
}
