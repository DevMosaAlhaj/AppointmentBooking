using Appointment_Booking.Data;
using Appointment_Booking.Data.Dto;
using Appointment_Booking.Data.Models;
using Appointment_Booking.Data.ViewModel;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Appointment_Booking.Service.Services.CampanyService
{
    public class CampanyService : ICampanyService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;


        public CampanyService (ApplicationDbContext dbContext , IMapper mapper)
        {
            this.dbContext = dbContext; 
            this.mapper = mapper; 
        }

        public void AddCampany(CampanyDto dto)
        {
            Campany company = mapper.Map<CampanyDto, Campany>(dto);

            dbContext.Campanies.Add(company);

            dbContext.SaveChanges();

            
        }

        public void EditCampany(CampanyDto dto)
        {

            Campany myCampany = dbContext.Campanies.Include(x => x.Address).SingleOrDefault(x => x.Id == dto.Id);

            Campany company = mapper.Map<CampanyDto, Campany>(dto,myCampany);

            dbContext.Campanies.Update(company);

            dbContext.SaveChanges();


        }

        
        public void DeleteCampany(int id)
        {

            Campany company = dbContext.Campanies.Find(id);

            dbContext.Campanies.Remove(company);

            dbContext.SaveChanges();


        }

        public CampanyViewModel GetCampany(int id)
        {

            Campany company = dbContext.Campanies.Include(x => x.Address).SingleOrDefault(x => x.Id == id);

            var companyViewModel = mapper.Map<Campany, CampanyViewModel>(company);

            return companyViewModel;    

        }

        public List<CampanyViewModel> GetAllCampanies ()
        {
            var campanies = dbContext.Campanies.Include(x => x.Address).ToList();

            var campaniesViewModel = mapper.Map<List<Campany>, List<CampanyViewModel>>(campanies);

            return campaniesViewModel;
        }

        public PagingViewModel<CampanyViewModel> GetCampanies(int page, string name)
        {

            var campaniesCount = dbContext.Campanies.Count(x => x.Name == name || String.IsNullOrEmpty(name) );

            var pageSize = 10.0;

            var pagesCount = Math.Ceiling(campaniesCount / pageSize);


            if (page > pagesCount || page <= 0)
                page = 1 ;


            var skipValue = ( page - 1 ) * pageSize;

            var campanies = dbContext.Campanies.Skip((int)skipValue).Take((int)pageSize).Where(x => string.IsNullOrEmpty(name) || x.Name.Contains(name)).Include(x => x.Address).OrderByDescending(a => a.Id).ToList();

            var campaniesViewModel = mapper.Map <List<Campany>,List<CampanyViewModel>> (campanies);
            
            PagingViewModel<CampanyViewModel> pvm = new PagingViewModel<CampanyViewModel>
            {
                PagesCount = (int)pagesCount,
                CurrentPage = page,
                Data = campaniesViewModel
            };

            return pvm;

        }
    }
}
