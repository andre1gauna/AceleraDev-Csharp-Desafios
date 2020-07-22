using System;
using System.Collections.Generic;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _service;

        public QuoteController(IQuoteService service)
        {
            _service = service;
        }

        // GET api/quote
        [HttpGet]
        public ActionResult<QuoteView> GetAnyQuote()
        {
            return QuoteToDTO(_service.GetAnyQuote());
        }

        // GET api/quote/{actor}
        [HttpGet("{actor}")]
        public ActionResult<QuoteView> GetAnyQuote(string actor)
        {
            var quoteView = QuoteToDTO(_service.GetAnyQuote(actor));

            if (quoteView is null)
                return NotFound();

            return quoteView;
        }

        private QuoteView QuoteToDTO(Quote quote)
        {
            if (quote is null)
                return null;

            QuoteView quoteView = new QuoteView();
            quoteView.Actor = quote.Actor;
            quoteView.Detail = quote.Detail;
            quoteView.Id = quote.Id;

            return quoteView;
        }

    }
}
