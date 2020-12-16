using Appointment_Booking.Data.Enums;


namespace Appointment_Booking.Data.Dto
{
    public class UserDto
    {

        public string Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public Gender Gender { get; set; }
        
        public string Phone { get; set; }

        public string Password { get; set; }

        public AddressDto Address { get; set; }
    }
}
