using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Service.Services.AppointmentService
{
    public interface IAppointmentService
    {
        PagingViewModel<AppointmentViewModel> GetAllAppointments(int page, int? campanyId, string userId, string date);

        AppointmentViewModel GetAppointment(int id);

        List<AppointmentViewModel> GetAppointments();
        List<AppointmentViewModel> AppointmentsSearch(int? campanyId, string userId, string date);

        void AddAppointment(AppointmentDto dto);

        void EditAppointment(AppointmentDto dto);

        void DeleteAppointment(int id);
    }
}
