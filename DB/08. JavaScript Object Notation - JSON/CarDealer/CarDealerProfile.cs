using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //CreateMap<Car, CarPartDTO>();

            CreateMap<CarPartDTO, Car>().ForMember(dest => dest.Make, x => x.MapFrom(src => src.Make));
        }
    }
}
