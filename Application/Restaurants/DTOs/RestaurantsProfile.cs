using Application.Restaurants.Commands.CreateRestaurant;
using Application.Restaurants.Commands.UpdateRestaurant;
using AutoMapper;
using Domain.Entities;

namespace Application.Restaurants.DTOs;

public class RestaurantsProfile : Profile
{
    public RestaurantsProfile()
    {
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, o => o.MapFrom(s => s.Address == null ? null : s.Address.City))
            .ForMember(d => d.Street, o => o.MapFrom(s => s.Address == null ? null : s.Address.Street))
            .ForMember(d => d.PostalCode, o => o.MapFrom(s => s.Address == null ? null : s.Address.PostalCode));

        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(d => d.Address, o => o.MapFrom(s => new Address
            {
                City = s.City,
                Street = s.Street,
                PostalCode = s.PostalCode
            }));
        CreateMap<UpdateRestaurantCommand, Restaurant>();
    }
}