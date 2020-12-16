using Appointment_Booking.Data;
using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Models;
using Appointment_Booking.Data.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appointment_Booking.Service.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {

        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public AppointmentService(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }


        public PagingViewModel<AppointmentViewModel> GetAllAppointments(int page , int? campanyId , string userId , string date)
        {

            var appointmentCount = dbContext.Appointments.Count(i => (campanyId == null || i.CampanyId == campanyId) &&
                (String.IsNullOrEmpty(userId) || i.UserId == userId) &&
                (String.IsNullOrEmpty(date) || (i.BookingDateTime.Year + "/" + i.BookingDateTime.Month + "/" + i.BookingDateTime.Day) == date));

            var pageSize = 10.0;

            var pagesCount = Math.Ceiling(appointmentCount / pageSize);

            if (page < 1 || page > pagesCount)
                page = 1;

            var skipvalue = (page - 1) * pagesCount;

            

            var appointments = dbContext.Appointments.Include(x => x.Campany).Include(a => a.User).Skip((int)skipvalue).Take((int)pageSize)
                .OrderByDescending(a => a.Id).Where(i => (campanyId == null || i.CampanyId == campanyId ) && 
                ( String.IsNullOrEmpty(userId) || i.UserId == userId ) && 
                ( String.IsNullOrEmpty(date) || (i.BookingDateTime.Year+"/"+i.BookingDateTime.Month+"/"+i.BookingDateTime.Day) == date )  ).ToList();

            var appointmentsViewModel = mapper.Map<List<Appointment>, List<AppointmentViewModel>>(appointments);

            PagingViewModel<AppointmentViewModel> pvm = new PagingViewModel<AppointmentViewModel>()
            {
                PagesCount = (int)pagesCount,
                CurrentPage = page,
                Data = appointmentsViewModel,
            };


            return pvm;
        }

        public List<AppointmentViewModel> GetAppointments()
        {

            var appointments = dbContext.Appointments.Include(x => x.Campany).Include(a => a.User)
                .OrderByDescending(a => a.Id).ToList();

            var appointmentsViewModel = mapper.Map<List<Appointment>, List<AppointmentViewModel>>(appointments);


            return appointmentsViewModel;
        }

        public List<AppointmentViewModel> AppointmentsSearch(int? campanyId, string userId, string date)
        {

            var appointments = dbContext.Appointments.Include(x => x.Campany).Include(a => a.User)
                .OrderByDescending(a => a.Id).Where(p => (p.CampanyId == campanyId || campanyId == null) && (p.UserId == userId || String.IsNullOrEmpty(userId)) &&
                ( (p.BookingDateTime.Year+"/"+ p.BookingDateTime.Month + "/" + p.BookingDateTime.Day ) == date ) ).ToList();

            var appointmentsViewModel = mapper.Map<List<Appointment>, List<AppointmentViewModel>>(appointments);


            return appointmentsViewModel;
        }


        public AppointmentViewModel GetAppointment(int id)
        {

            Appointment appointment = dbContext.Appointments.Include(x => x.Campany).Include(a => a.User).SingleOrDefault(a => a.Id == id);

            AppointmentViewModel appointmentViewModel = mapper.Map<Appointment, AppointmentViewModel>(appointment);

          
            return appointmentViewModel;

        }
        public void AddAppointment(AppointmentDto dto)
        {


            Appointment appointment = mapper.Map<AppointmentDto, Appointment>(dto);

            dbContext.Appointments.Add(appointment);

            dbContext.SaveChanges();


        }


        public void EditAppointment(AppointmentDto dto)
        {

            Appointment myAppointment = dbContext.Appointments.Include(a => a.User).Include(x => x.Campany).SingleOrDefault(i => i.Id == dto.Id);
            Appointment appointment = mapper.Map<AppointmentDto, Appointment>(dto, myAppointment);

            dbContext.Appointments.Update(appointment);

            dbContext.SaveChanges();


        }


        public void DeleteAppointment(int id)
        {

            Appointment appointment = dbContext.Appointments.Find(id);


            dbContext.Appointments.Remove(appointment);

            dbContext.SaveChanges();


        }



    }
}
