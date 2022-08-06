using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            

            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var inputJason1 = File.ReadAllText("../../../Datasets/suppliers.json");
            var inputJason2 = File.ReadAllText("../../../Datasets/parts.json");
            var inputJason3 = File.ReadAllText("../../../Datasets/cars.json");

            Console.WriteLine(ImportSuppliers(context, inputJason1));
            Console.WriteLine(ImportParts(context, inputJason2));
            Console.WriteLine(ImportCars(context, inputJason3));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<IEnumerable<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<IEnumerable<Part>>(inputJson);
            parts = parts.Where(p => context.Suppliers.Select(s => s.Id).Contains(p.SupplierId));

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            
            

            //context.Cars.AddRange(cars);
            //context.SaveChanges();

            
            return $"Successfully imported {carsDto.Count()}.";
        }
    }
}