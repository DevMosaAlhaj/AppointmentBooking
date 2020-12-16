using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Appointment_Booking.Data.Models
{
    public class Campany
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        
        public Address Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Website { get; set; }

        [Required]
        public DateTime WorkStart { get; set; }

        [Required]
        public DateTime WorkEnd { get; set; }

        [NotMapped]
        public List<Appointment> Appointments { get; set; }


 
    }
}
