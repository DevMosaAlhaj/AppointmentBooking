using Appointment_Booking.Data.Enums;
using Appointment_Booking.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Data.ViewModel
{
    public class UserViewModel
    {

        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }
        
        public string Phone { get; set; }

        public Address Address { get; set; }

     
    }
}
