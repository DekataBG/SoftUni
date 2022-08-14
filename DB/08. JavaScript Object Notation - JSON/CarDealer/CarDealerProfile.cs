using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.DTO.ExportDto;
using CarDealer.DTO.ImportDto;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            CreateMap<CarImportDto, Car>();

            CreateMap<Customer, CustomerExportDto>()
                .ForMember(cdto => cdto.BirthDate, x => x.MapFrom(
                    c => c.BirthDate.ToString("dd/MM/yyyy")));

            CreateMap<Car, CarExportDto>();
        }
    }
}
