using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context.Candidates.Where(c => c.AccelerationId == accelerationId && c.UserId == userId)
                                      .Select(ch => ch.Acceleration.Challenge).ToList();                                     

        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                _context.Challenges.Update(challenge);
            else
                _context.Challenges.Add(challenge);
            return challenge;
        }
    }
}