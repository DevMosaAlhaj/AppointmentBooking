using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Appointment_Booking.Data.Models
{
    public class Address
    {

        public int Id { get; set; }

      
        public string CountryName { get; set; }

        
        public string CityName { get; set; }

        
        public string StreetName { get; set; }

        public string Longtitude { get; set; }

        public string Latitude { get; set; }
            
    }
}
