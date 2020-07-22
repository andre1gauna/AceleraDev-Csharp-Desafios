using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Codenation.Challenge.DTOs;
using Codenation.Challenge.Services;
using Microsoft.AspNetCore.Mvc;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : ControllerBase
    {
        private readonly IChallengeService _service;
        private readonly IMapper _mapper;
        
        public ChallengeController (IChallengeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/challenge
        [HttpGet]
        public ActionResult<IEnumerable<ChallengeDTO>> GetAll(int? accelerationId = null, int? userId = null)
        {
            if ((accelerationId is null) && (userId is null))
                return NoContent();
            
            return Ok(_mapper.Map<List<ChallengeDTO>>(_service.FindByAccelerationIdAndUserId(accelerationId.Value, userId.Value)));
        }

        //POST api/challenge

        [HttpPost]
        public ActionResult<ChallengeDTO> Post([FromBody] ChallengeDTO value)
        {
           

            var entity = _mapper.Map<Models.Challenge>(value);
            var result = _service.Save(entity);
            var entityDTO = _mapper.Map<ChallengeDTO>(result);
            return Ok(entityDTO);
        }
    }
}
