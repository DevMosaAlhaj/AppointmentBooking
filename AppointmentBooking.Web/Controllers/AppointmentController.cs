using Appointment_Booking.Data.Dto;
using Appointment_Booking.Service.Services.AppointmentService;
using Appointment_Booking.Service.Services.CampanyService;
using Appointment_Booking.Service.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Appointment_Booking.Web.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly IAppointmentService appointmentService;
        private readonly ICampanyService campanyService;
        private readonly IUserService userService;

        public AppointmentController(IAppointmentService appointmentService, ICampanyService campanyService, IUserService userService)
        {
            this.appointmentService = appointmentService;
            this.campanyService = campanyService;
            this.userService = userService;
        }

        public IActionResult Index(int page, int? campanyId, string userId, DateTime? date)
        {
            string dateAfterFormat = "";

            if (date != null)
                dateAfterFormat = ((DateTime)date).ToString("yyyy/MM/dd");


            var appointmentsViewModel = appointmentService.GetAllAppointments(page, campanyId, userId, dateAfterFormat);

            var campaniesViewModel = campanyService.GetAllCampanies();
            var usersViewModel = userService.GetAllUsers();


            ViewBag.users = usersViewModel;
            ViewBag.campanies = campaniesViewModel;

            ViewBag.userId = userId;
            ViewBag.campanyId = campanyId;
            ViewBag.date = date;

            return View(appointmentsViewModel);
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {

            var campaniesViewModel = campanyService.GetAllCampanies();
            var usersViewModel = userService.GetAllUsers();

            ViewBag.users = usersViewModel;
            ViewBag.campanies = campaniesViewModel;

            return View();
        }


        [HttpPost]
        public IActionResult AddAppointment(AppointmentDto dto)
        {
            appointmentService.AddAppointment(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult EditAppointment(int id)
        {

            var campaniesViewModel = campanyService.GetAllCampanies();
            var usersViewModel = userService.GetAllUsers();
            var appointmentViewModel = appointmentService.GetAppointment(id);

            ViewBag.users = usersViewModel;
            ViewBag.campanies = campaniesViewModel;
            ViewBag.appointment = appointmentViewModel;

            return View();
        }

        [HttpPost]
        public IActionResult EditAppointment(AppointmentDto dto)
        {

            appointmentService.EditAppointment(dto);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteAppointment(int id)
        {

            appointmentService.DeleteAppointment(id);


            return RedirectToAction("Index");
        }

    }
}
