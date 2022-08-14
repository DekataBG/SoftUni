using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var mapper = CreateMapper();

            var context = new CarDealerContext();

            //InitializeDatabase(context);

            //var importCars = File.ReadAllText(GetFileDirectory("cars"));
            //var importCustomers = File.ReadAllText(GetFileDirectory("customers"));
            //var importParts = File.ReadAllText(GetFileDirectory("parts"));
            //var importSales = File.ReadAllText(GetFileDirectory("sales"));
            //var importSuppliers = File.ReadAllText(GetFileDirectory("suppliers"));

            //Console.WriteLine(ImportSuppliers(context, importSuppliers));
            //Console.WriteLine(ImportParts(context, importParts));
            //Console.WriteLine(ImportCars(context, importCars));
            //Console.WriteLine(ImportCustomers(context, importCustomers));
            //Console.WriteLine(ImportSales(context, importSales));

            //Console.WriteLine(GetOrderedCustomers(context));
            //Console.WriteLine(GetCarsFromMakeToyota(context));
            //Console.WriteLine(GetLocalSuppliers(context));
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));
            //Console.WriteLine(GetTotalSalesByCustomer(context));
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = Deserialize<Supplier>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = Deserialize<Part>(inputJson);

            parts = parts.Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = Deserialize<CarImportDto>(inputJson);

            var cars = carsDto.Select(c => new Car
            {
                Make = c.Make,
                Model = c.Model,
                TravelledDistance = c.TravelledDistance,
                PartCars = context.Parts
                    .ToList()
                    .Select(p => p.Id)
                    .Intersect(c.PartsId)
                    .Distinct()
                    .Select(id => new PartCar
                    {
                        PartId = id
                    })
                    .ToList()
            })
            .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();
            
            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = Deserialize<Customer>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = Deserialize<Sale>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }


        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ToArray();

            var customersDto = MapObjectToDto<Customer, CustomerExportDto>(customers, mapper);

            return Serialize<CustomerExportDto[]>(customersDto);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var carsDto = MapObjectToDto<Car, CarExportDto>(cars, mapper);

            return Serialize<CarExportDto[]>(carsDto);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var suppliersDto = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new SupplierExportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();


            return Serialize<SupplierExportDto[]>(suppliersDto);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var mapper = CreateMapper();

            var carsDto = context.Cars
                .Select(c => new CarPartExportDto
                {
                    car = new CarExportDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(pc => pc.Part)
                        .Select(p => new PartExportDto
                        {
                            Name = p.Name,
                            Price = $"{p.Price:f2}"
                        })
                        .ToArray()
                })
                .ToArray();

            return Serialize<CarPartExportDto[]>(carsDto);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                        .Select(s => s.Car)
                        .SelectMany(c => c.PartCars)
                        .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString(),
                    price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString(),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -
                    s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100).ToString()
                })
                .Take(10);
           
            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }


        private static void InitializeDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        private static string GetFileDirectory(string file)
        {
            return $"../../../Datasets/{file}.json";
        }

        private static IEnumerable<T> Deserialize<T>(string inputJson)
        {
            var objects = JsonConvert.DeserializeObject<IEnumerable<T>>(inputJson);

            return objects;
        }

        private static string Serialize<T>(T objects)
        {
            return JsonConvert.SerializeObject(objects, Formatting.Indented);
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

        private static TDto[] MapObjectToDto<T, TDto>(T[] objects, IMapper mapper)
        {
            var dtos = mapper.Map<TDto[]>(objects);

            return dtos;
        }
    }
}