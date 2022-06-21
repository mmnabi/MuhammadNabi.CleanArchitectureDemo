using AutoMapper;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Commands.CreateCategory;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryList;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Categories.Queries.GetCategoryListWithEvents;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Commands.CreateEvent;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Commands.UpdateEvent;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventDetail;
using MuhammadNabi.CleanArchitectureDemo.Application.Features.Events.Queries.GetEventList;
using MuhammadNabi.CleanArchitectureDemo.Domain.Entities;

namespace MuhammadNabi.CleanArchitectureDemo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListViewModel>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailViewModel>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListViewModel>();
            CreateMap<Category, CategoryEventListViewModel>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            //CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
