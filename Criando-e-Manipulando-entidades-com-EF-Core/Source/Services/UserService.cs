using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private readonly CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
            return _context.Candidates.Where(a => a.Acceleration.Name == name)
                                      .Select(u => u.User)
                                      .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
            return _context.Candidates.Where(c => c.Company.Id == companyId )
                                                  .Select(u => u.User)
                                                  .ToList();
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
                                                  
        }

        public User Save(User user)
        {
            if (user.Id == 0)
                _context.Users.Add(user);
            else
                _context.Users.Update(user);
            return user;
        }
    }
}
