using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Booking.BusinessLayer.Abstract;
using Booking.Dto;
using Booking.DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Booking.BusinessLayer.Services
{
    public class CompanmyService : ICompanyService
    {
        private readonly BookingContext _context;
        private readonly IMapper _mapper;

        public CompanmyService(BookingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Guid AddCompany(Company company)
        {
            var companyDL = new DataLayer.Tables.Companies.Company();
            _mapper.Map(company, companyDL);
            companyDL.Id = Guid.NewGuid();
            _context.Companies.Add(companyDL);
            _context.SaveChanges();
            return companyDL.Id;
        }

        public async Task<Company> EditCompany(Company company)
        {
            var companyDL = await _context.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);
            if (companyDL is not null)
            {
                companyDL.Name = company.Name is not null ? company.Name : companyDL.Name;
                companyDL.Description = company.Description is not null ? company.Description : companyDL.Description;
                companyDL.ModifiedAt = DateTime.Now;
                companyDL.ModifyReason = "CompanyServiceApiRequest";
                _context.SaveChanges();
            }

            return _mapper.Map<Company>(companyDL);
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var domainCompanies = await _context.Companies.ToListAsync();
            var dtoCompanies = _mapper.Map<IEnumerable<Company>>(domainCompanies);
            return dtoCompanies;
        }
    }
}