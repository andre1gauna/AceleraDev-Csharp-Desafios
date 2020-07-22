using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _service;
        private readonly IMapper _mapper;
        public SubmissionController(ISubmissionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/submission/higherScore
        [HttpGet("{id}")]
        public ActionResult<decimal> GetHigherScore(int? challengeId = null)
        {
            if (challengeId is null)
                return NoContent();
            
            return Ok(_service.FindHigherScoreByChallengeId(challengeId.Value));
        }

        //GET api/submission
        [HttpGet]
        public ActionResult<IEnumerable<SubmissionDTO>> GetAll(int? challengeId = null, int? accelerationId = null)
        {
            if ((challengeId is null) && (accelerationId is null))
                return NoContent();

            return Ok(_mapper.Map<List<SubmissionDTO>>(_service.FindByChallengeIdAndAccelerationId(challengeId.Value, accelerationId.Value)));
        }

        // POST api/submission
        [HttpPost]
        public ActionResult<SubmissionDTO> Post([FromBody] SubmissionDTO value)
        {
           

            var entity = _mapper.Map<Submission>(value);
            var result = _service.Save(entity);
            var entityDTO = _mapper.Map<SubmissionDTO>(result);
            return Ok(entityDTO);
        }
    }
}
