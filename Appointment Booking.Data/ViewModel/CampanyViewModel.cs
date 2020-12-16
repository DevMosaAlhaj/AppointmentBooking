using Appointment_Booking.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Data.ViewModel
{
    public class CampanyViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public AddressViewModel Address { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public string Website { get; set; }
        
        public string WorkStart { get; set; }

        
        public string WorkEnd { get; set; }


    }
}
