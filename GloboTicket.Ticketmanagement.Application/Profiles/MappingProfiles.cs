using AutoMapper;
using GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryList;
using GloboTicket.Ticketmanagement.Application.Features.Category.Queries.GetCategoryListWithEvents;
using GloboTicket.Ticketmanagement.Application.Features.Events;
using GloboTicket.Ticketmanagement.Application.Features.Events.Command.CreateEvent;
using GloboTicket.Ticketmanagement.Application.Features.Events.Command.UpdateEvent;
using GloboTicket.Ticketmanagement.Application.Features.Category.Command.CreateCategory;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Ticketmanagement.Application.Features.Events.Queries.GetEventsExport;

namespace GloboTicket.Ticketmanagement.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventListVM>().ReverseMap();
            CreateMap<Event, EventDetailsVM>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryListVM>().ReverseMap();
            CreateMap<Category, CategoryEventListVM>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
