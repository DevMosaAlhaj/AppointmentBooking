using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Data.Dto
{
   public class CampanyDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        
        public AddressDto Address { get; set; }

        
        public string PhoneNumber { get; set; }

        
        public string Email { get; set; }

        public string Website { get; set; }

        
        public DateTime WorkStart { get; set; }

        
        public DateTime WorkEnd { get; set; }

    }
}
