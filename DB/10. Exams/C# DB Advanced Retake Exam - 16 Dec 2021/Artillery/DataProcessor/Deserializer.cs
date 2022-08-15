namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using AutoMapper;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var stringBuilder = new StringBuilder();

            var countriesDto = XmlDeserialize<CountryImportDto[]>("Countries", xmlString);

            var countries = new List<Country>();

            foreach (var countryDto in countriesDto)
            {
                if(!IsValid(countryDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var country = Mapper.Map<Country>(countryDto);
                countries.Add(country);

                stringBuilder.AppendLine(
                    String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return stringBuilder.ToString();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var stringBuilder = new StringBuilder();

            var manufacturersDto = XmlDeserialize<ManufacturerImportDto[]>("Manufacturers", xmlString);

            var manufacturers = new List<Manufacturer>();

            foreach (var manufacturerDto in manufacturersDto)
            {
                if (!IsValid(manufacturerDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = Mapper.Map<Manufacturer>(manufacturerDto);

                if (!manufacturers.Any(m => m.ManufacturerName == manufacturer.ManufacturerName))
                {
                    manufacturers.Add(manufacturer);

                    var town = manufacturer.Founded.Split(", ")[manufacturer.Founded.Split(", ").Length - 2];
                    var country = manufacturer.Founded.Split(", ")[manufacturer.Founded.Split(", ").Length - 1];
                    var founded = $"{town}, {country}";

                    stringBuilder.AppendLine(
                       String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, founded));
                }
                else
                {
                    stringBuilder.AppendLine(ErrorMessage);
                }
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return stringBuilder.ToString();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var stringBuilder = new StringBuilder();

            var shellsDto = XmlDeserialize<ShellImportDto[]>("Shells", xmlString);

            var shells = new List<Shell>();

            foreach (var shellDto in shellsDto)
            {
                if(!IsValid(shellDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = Mapper.Map<Shell>(shellDto);
                shells.Add(shell);

                stringBuilder.AppendLine(
                    String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return stringBuilder.ToString();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var stringBuilder = new StringBuilder();

            var gunsDto = JsonConvert.DeserializeObject<GunImportDto[]>(jsonString);

            var guns = new List<Gun>();

            foreach (var gunDto in gunsDto)
            {
                if (!IsValid(gunDto))
                {
                    stringBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    GunWeight = gunDto.GunWeight,
                    BarrelLength  = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild != null ? gunDto.NumberBuild : 0,
                    Range = gunDto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gunDto.GunType),
                    ManufacturerId  = gunDto.ManufacturerId,
                    ShellId = gunDto.ShellId,
                    CountriesGuns = gunDto.Countries
                        .Select(c => new CountryGun
                        {
                            CountryId = c.Id
                        }).ToArray()
                };
                guns.Add(gun);

                stringBuilder.AppendLine(
                    String.Format(SuccessfulImportGun, gun.GunType.ToString(), gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

            return stringBuilder.ToString();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
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
