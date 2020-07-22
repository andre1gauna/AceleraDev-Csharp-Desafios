using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            int NumberOfQuotes = _context.Quotes.Count();
            int randIndex = _randomService.RandomInteger(NumberOfQuotes);
            return _context.Quotes.ElementAtOrDefault(randIndex);                                  
        }

        public Quote GetAnyQuote(string actor)
        {
            var QuotesList = _context.Quotes.Where(x => x.Actor == actor)
                                            .ToList();

            int NumberOfQuotes = QuotesList.Count();
            int randIndex = _randomService.RandomInteger(NumberOfQuotes);
            return QuotesList.ElementAtOrDefault(randIndex);
        }
    }
}