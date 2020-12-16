using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Enums;
using Appointment_Booking.Service.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Appointment_Booking.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;


        public UserController (IUserService userService)
        {
            this.userService = userService;
     
        }


        public IActionResult Index(int id,string name , Gender? gender)
        {
            var users = userService.GetUsers(id,name,gender);

            ViewBag.name = name;
            ViewBag.gender = gender;

            return View(users);
        }

       

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto dto)
        {

            bool result = await userService.AddUser(dto);
            
            return RedirectToAction(result ? "Index" : "AddUser") ;
        }


        [HttpGet]
        public IActionResult EditUser(string id)
        {
            var userViewModel = userService.GetUser(id);
            ViewBag.user = userViewModel;
            return View();
        }

        [HttpPost]
        public IActionResult EditUser(UserDto dto)
        {

            userService.EditUser(dto);

            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(string id)
        {

            userService.DeleteUser(id);

            return RedirectToAction("Index");
        }

    }
}
