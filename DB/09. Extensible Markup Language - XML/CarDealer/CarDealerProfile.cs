using AutoMapper;
using CarDealer.ExportDto;
using CarDealer.ImportDto;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<SupplierImportDto, Supplier>();

            CreateMap<PartImportDto, Part>();

            CreateMap<CarImportDto, Car>();

            CreateMap<CustomerImportDto, Customer>();

            CreateMap<SaleImportDto, Sale>();

            CreateMap<Car, CarExportDto>();

            CreateMap<Car, BmwCarExportDto>();

            CreateMap<Supplier, SupplierExportDto>();

            CreateMap<Part, PartExportDto>();

            CreateMap<Car, CarWithPartsExportDto>()
                .ForMember(cdto => cdto.Parts, x => x.MapFrom(
                    c => c.PartCars
                    .Select(cp => cp.Part)
                    .OrderByDescending(p => p.Price)
                    ));

            CreateMap<Customer, CustomerExportDto>()
                .ForMember(cdto => cdto.SalesCount, x => x.MapFrom(
                    c => c.Sales.Count()))
                .ForMember(cdto => cdto.SpentMoney, x => x.MapFrom(
                    c => c.Sales
                    .Select(s => s.Car)
                    .SelectMany(c => c.PartCars)
                    .Sum(pc => pc.Part.Price)));

            CreateMap<Sale, SaleExportDto>()                
                .ForMember(sdto => sdto.Price, x => x.MapFrom(
                    c => c.Car.PartCars.Sum(pc => pc.Part.Price)))
                //.ForMember(sdto => sdto.PriceWithDiscount, x => x.MapFrom(
                //c => c.Car.PartCars.Sum(pc => pc.Part.Price) * (100 - c.Discount) / 100));
                .ForMember(sdto => sdto.PriceWithDiscount, x => x.MapFrom(
                    c => c.Car.PartCars.Sum(pc => pc.Part.Price) - c.Car.PartCars.Sum(pc => pc.Part.Price) * c.Discount / 100));

        }
    }
}
