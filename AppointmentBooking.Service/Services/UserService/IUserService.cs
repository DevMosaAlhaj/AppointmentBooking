using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Enums;
using Appointment_Booking.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking.Service.Services.UserService
{
    public interface IUserService
    {

        PagingViewModel<UserViewModel> GetUsers(int page,string name , Gender? gender);
        UserViewModel GetUser(string id);

        List<UserViewModel> GetAllUsers();

        Task<bool> AddUser(UserDto dto);

        void EditUser(UserDto dto);

        void DeleteUser(string id);

    }
}
