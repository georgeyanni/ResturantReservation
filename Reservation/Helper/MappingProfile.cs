using AutoMapper;
using Reservation.Dtos;
using Reservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationDto, ReservationTable>();

            CreateMap<ReservationTable, ReservationDto>()
                .ForMember(j => j.Name, k => k.MapFrom(l => l.User.Name))
                 .ForMember(x => x.FoodType, y => y.MapFrom(z => z.FoodType.FoodType));
        }
    }
}
