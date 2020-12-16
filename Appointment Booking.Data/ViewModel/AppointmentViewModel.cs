using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Data.ViewModel
{
    public class AppointmentViewModel
    {

        public int Id { get; set; }
        public string CampanyName { get; set; }
        public int CampanyId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime BookingDateTime { get; set; }
        public string Description { get; set; }

    }
}
