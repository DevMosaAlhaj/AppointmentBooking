using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Appointment_Booking.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int CampanyId { get; set; }

        [ForeignKey("CampanyId")]
        public Campany Campany { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public DateTime BookingDateTime { get; set; }

        public string Description { get; set; }
    }
}
