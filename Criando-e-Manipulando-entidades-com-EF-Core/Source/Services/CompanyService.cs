using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates.Where(id => id.Acceleration.Id == accelerationId)
                                      .Select(c => c.Company)
                                      .ToList();
        }

        public Company FindById(int id)
        {
            return _context.Companies.FirstOrDefault(u => u.Id == id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context.Candidates.Where(id => id.User.Id == userId)
                                                  .Select(c => c.Company)
                                                  .ToList();
        }

        public Company Save(Company company)
        {
            if (company.Id == 0)
                _context.Companies.Add(company);
            else
                _context.Companies.Update(company);
            return company;
        }
    }
}