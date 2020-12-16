using Appointment_Booking.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Appointment_Booking.Data.Models
{
     public class User : IdentityUser
    {

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public Address Address { get; set; }

        [NotMapped]
        public List<Appointment> Appointments { get; set; }

        
    }
}
