using Appointment_Booking.Data.ViewModel;
using System;

namespace Appointment_Booking.Data.Dto
{
   public class AppointmentDto
    {
        public int Id { get; set; } 
        public int CampanyId { get; set; }
        public string UserId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public string Description { get; set; }

    }
}
