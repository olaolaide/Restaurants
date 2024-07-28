using Application.Dishes.Commands.CreateDish;
using Application.Dishes.Commands.UpdateDish;
using AutoMapper;
using Domain.Entities;

namespace Application.Dishes.DTOs
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<CreateDishCommand, Dish>();
            CreateMap<UpdateDishCommand, Dish>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}