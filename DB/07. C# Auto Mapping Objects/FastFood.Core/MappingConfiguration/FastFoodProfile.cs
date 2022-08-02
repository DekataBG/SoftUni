﻿namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using System;
    using System.Linq;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));


            //Employees
            this.CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            //Profiles
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(s => s.Name));

            this.CreateMap<CreateItemInputModel, Item>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(s => s.EmployeeId));

            this.CreateMap<Order, CreateOrderInputModel>()
                .ForMember(x => x.ItemId, y => y.MapFrom(s => s.OrderItems.Select(oi => oi.ItemId)));

            this.CreateMap<Order, CreateOrderInputModel>()
                .ForMember(x => x.ItemName, y => y.MapFrom(s => s.OrderItems.Select(oi => oi.Item.Name)));

            this.CreateMap<Order, CreateOrderInputModel>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(s => s.EmployeeId));

            this.CreateMap<Order, CreateOrderInputModel>()
                .ForMember(x => x.EmployeeName, y => y.MapFrom(s => s.Employee.Name));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name));

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.DateTime, y => y.MapFrom(s => DateTime.UtcNow));
        }
    }
}
