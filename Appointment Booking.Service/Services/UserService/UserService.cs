using Appointment_Booking.Data;
using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Enums;
using Appointment_Booking.Data.Models;
using Appointment_Booking.Data.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment_Booking.Service.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UserService (ApplicationDbContext dbContext , IMapper mapper , UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.userManager = userManager;
        }


        public List<UserViewModel> GetAllUsers ()
        { 

            var users = dbContext.Users.Include(x => x.Address).ToList();

            var usersViewModel = mapper.Map<List<User>, List<UserViewModel>>(users);

            return usersViewModel;
        }

        public PagingViewModel<UserViewModel> GetUsers(int page,string name ,Gender? gender)
        {

            var usersCount = dbContext.Users.Count(x => (String.IsNullOrEmpty(name) || (x.FirstName.Contains(name) || x.LastName.Contains(name)))
                && (gender == null || x.Gender == gender));

            var pageSize = 10.0;

            var pagesCount = Math.Ceiling(usersCount / pageSize);

            if (page < 1 || page > pagesCount)
                page = 1;

            var skipValue = (page - 1) * pagesCount;

            var users = dbContext.Users.Skip((int)skipValue).Take((int)pageSize).Include(x => x.Address)
                .Where(x => ( String.IsNullOrEmpty(name) || (x.FirstName.Contains(name) || x.LastName.Contains(name) ))
                && ( gender == null || x.Gender == gender) ).ToList();
            
            var usersViewModel = mapper.Map<List<User>, List<UserViewModel>>(users);
            
            PagingViewModel<UserViewModel> pvm = new PagingViewModel<UserViewModel>()
            {

                PagesCount = (int)pagesCount,
                CurrentPage = page,
                Data = usersViewModel,

            
            };


            return pvm;

        }

        public async Task<bool> AddUser (UserDto dto)
        {

            User user = mapper.Map<UserDto, User>(dto);

            user.UserName = user.Email;

            var result = await userManager.CreateAsync(user, dto.Password);

            return result.Succeeded;

        }

        public void EditUser (UserDto dto)
        {
            User myUser = dbContext.Users.Include(x => x.Address).SingleOrDefault(a => a.Id == dto.Id);

            User user = mapper.Map<UserDto, User>(dto,myUser);

            dbContext.Update(user);

            dbContext.SaveChanges();

        }

        public void DeleteUser(string id)
        {
            User user = dbContext.Users.Include(x => x.Address).SingleOrDefault(a => a.Id == id);

            dbContext.Remove(user);

            dbContext.SaveChanges();

        }

        public UserViewModel GetUser(string id)
        {
            User user = dbContext.Users.Include(x => x.Address).SingleOrDefault(a => a.Id == id);

            UserViewModel userViewModel = mapper.Map<User, UserViewModel>(user);

            return userViewModel;
        }
    }
}
