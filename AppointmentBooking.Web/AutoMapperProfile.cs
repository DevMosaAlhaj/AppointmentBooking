using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Models;
using Appointment_Booking.Data.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_Booking.Web
{
    public class AutoMapperProfile : Profile
    {
        
        public AutoMapperProfile ()
        {
            CreateMap<CampanyDto, Campany>();
            CreateMap<Campany, CampanyViewModel>().ForMember(x => x.WorkStart , x => x.MapFrom(a => a.WorkStart.ToString("hh:mm tt")))
                .ForMember(x => x.WorkEnd, x => x.MapFrom(a => a.WorkEnd.ToString("hh:mm tt")));
            CreateMap<CampanyViewModel, Campany>().ForMember(x => x.WorkStart , otp => otp.Ignore())
                .ForMember(x => x.WorkEnd, otp => otp.Ignore());
            CreateMap<AddressDto, Address>();
            CreateMap<UserDto, User>().ForMember(a => a.Address, a => a.MapFrom(x => x.Address)).ForMember(a => a.Id, otp => otp.Ignore());
            CreateMap<User, UserViewModel>();
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<Appointment, AppointmentViewModel>().ForMember(y => y.CampanyName, y => y.MapFrom(d => d.Campany.Name))
                .ForMember(y => y.UserName, y => y.MapFrom(d => d.User.FullName)) ;
            CreateMap<Address, AddressViewModel>();
        }

    }
}
