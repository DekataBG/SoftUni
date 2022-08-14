using AutoMapper;
using CarDealer.Data;
using CarDealer.ExportDto;
using CarDealer.ImportDto;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            var context = new CarDealerContext();

            //InitialiseDatabase(context);
            //
            //Console.WriteLine(ImportSuppliers(context, File.ReadAllText("../../../Datasets/suppliers.xml")));
            //Console.WriteLine(ImportParts(context, File.ReadAllText("../../../Datasets/parts.xml")));
            //Console.WriteLine(ImportCars(context, File.ReadAllText("../../../Datasets/cars.xml")));
            //Console.WriteLine(ImportCustomers(context, File.ReadAllText("../../../Datasets/customers.xml")));
            //Console.WriteLine(ImportSales(context, File.ReadAllText("../../../Datasets/sales.xml")));

            //Console.WriteLine(GetCarsWithDistance(context));
            //Console.WriteLine(GetCarsFromMakeBmw(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            //Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var mapper = CreateMapper();

            var suppliersDto = Deserialize<SupplierImportDto[]>("Suppliers", inputXml);

            var suppliers = MapDtosToObjects<Supplier, SupplierImportDto>(suppliersDto, mapper);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var mapper = CreateMapper();

            var partsDto = Deserialize<PartImportDto[]>("Parts", inputXml);

            var parts = MapDtosToObjects<Part, PartImportDto>(partsDto, mapper)
                .Where(p => context.Suppliers.Select(s => s.Id).ToList().Contains(p.SupplierId)).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var mapper = CreateMapper();

            var carsDto = Deserialize<CarImportDto[]>("Cars", inputXml);

            var cars = MapDtosToObjects<Car, CarImportDto>(carsDto, mapper);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            foreach (var carDto in carsDto)
            {
                carDto.Parts = carDto.Parts
                    .Select(p => p.Id)
                    .Intersect(context.Parts.Select(p => p.Id))
                    .Distinct()
                    .Select(pcId => new PartIdImportDto
                    {
                        Id = pcId
                    })
                    .ToArray();
            }

            foreach (var carDto in carsDto)
            {
                var carId = context.Cars
                    .Where(c => c.Make == carDto.Make && c.Model == carDto.Model && c.TravelledDistance == carDto.TravelledDistance)
                    .FirstOrDefault().Id;

                foreach (var partDto in carDto.Parts)
                {
                    {
                        var partCar = new PartCar
                        {
                            PartId = partDto.Id,
                            CarId = carId
                        };

                        context.PartCars.Add(partCar);
                        context.SaveChanges();

                        context.Cars.Find(carId).PartCars.Add(partCar);
                        context.SaveChanges();
                    }
                }
            }

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var mapper = CreateMapper();

            var customersDto = Deserialize<CustomerImportDto[]>("Customers", inputXml);

            var customers = MapDtosToObjects<Customer, CustomerImportDto>(customersDto, mapper);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var mapper = CreateMapper();

            var salesDto = Deserialize<SaleImportDto[]>("sales", inputXml);

            var sales = MapDtosToObjects<Sale, SaleImportDto>(salesDto, mapper);

            sales = sales
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10);

            var carsDto = MapObjectsToDtos<Car, CarExportDto>(cars, mapper);

            return Serialize<CarExportDto[]>("cars", carsDto);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance);

            var carsDto = MapObjectsToDtos<Car, BmwCarExportDto>(cars, mapper);

            return Serialize<BmwCarExportDto[]>("cars", carsDto);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter);

            var suppliersDto = MapObjectsToDtos<Supplier, SupplierExportDto>(suppliers, mapper);

            return Serialize<SupplierExportDto[]>("suppliers", suppliersDto);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5);

            var carsDto = MapObjectsToDtos<Car, CarWithPartsExportDto>(cars, mapper);

            return Serialize<CarWithPartsExportDto[]>("cars", carsDto);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .OrderByDescending(c => c.Sales
                    .Select(s => s.Car)
                    .SelectMany(c => c.PartCars)
                    .Sum(pc => pc.Part.Price));

            var customersDto = MapObjectsToDtos<Customer, CustomerExportDto>(customers, mapper);

            return Serialize<CustomerExportDto[]>("customers", customersDto);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var sales = context.Sales;

            var salesDto = MapObjectsToDtos<Sale, SaleExportDto>(sales, mapper);

            return Serialize<SaleExportDto[]>("sales", salesDto);
        }

        private static T Deserialize<T>(string rootName, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            //var namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(String.Empty, String.Empty);

            using var stringReader = new StringReader(inputXml);

            T objects = (T)serializer.Deserialize(stringReader);

            return objects;
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

        private static void InitialiseDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static List<T> MapDtosToObjects<T, TDto>(TDto[] dtos, IMapper mapper)
        {
            var objects = new List<T>();

            foreach (var dto in dtos)
            {
                objects.Add(mapper.Map<TDto, T>(dto));
            }

            return objects;
        }

        private static TDto[] MapObjectsToDtos<T, TDto>(IQueryable<T> objects, IMapper mapper)
        {
            return mapper.ProjectTo<TDto>(objects).ToArray();
        }

        private static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        }
    }
}