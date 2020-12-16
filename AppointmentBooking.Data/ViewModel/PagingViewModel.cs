using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Data.ViewModel
{
    public class PagingViewModel<Type>
    {

        public int PagesCount { get; set; }
        public int CurrentPage { get; set; }
        public List<Type> Data { get; set; }

    }
}
