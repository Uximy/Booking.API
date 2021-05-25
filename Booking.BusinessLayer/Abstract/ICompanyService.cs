using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Booking.Dto;

namespace Booking.BusinessLayer.Abstract
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanies();
        Guid AddCompany(Company company);
        Task<Company> EditCompany(Company company);
    }
}