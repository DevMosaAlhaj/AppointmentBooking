using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Appointment_Booking.Service.Services.CampanyService
{
    public interface ICampanyService
    {

        PagingViewModel<CampanyViewModel> GetCampanies(int page,string name);

        List<CampanyViewModel> GetAllCampanies();
        void AddCampany (CampanyDto dto);
        void EditCampany (CampanyDto dto);
        CampanyViewModel GetCampany(int id);
        void DeleteCampany (int id);


    }
}
