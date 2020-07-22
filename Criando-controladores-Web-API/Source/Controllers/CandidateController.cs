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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;
        private readonly IMapper _mapper;
        public CandidateController(ICandidateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/candidate/{userId}/{accelerationId}/{companyId}:
        [HttpGet("{userId}/{accelerationId}/{companyID}")]
        public ActionResult<CandidateDTO> Get(int userId, int accelerationId, int companyID)
        {
            return Ok(_mapper.Map<CandidateDTO>(_service.FindById(userId,accelerationId,companyID)));
        }

        //GET api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> GetAll(int? companyId = null, int? accelerationId = null)
        {
            if ((companyId is null && accelerationId is null) || (companyId != null && accelerationId != null))
                return NoContent();
            
            if (companyId is null)
                return Ok(_mapper.Map<List<CandidateDTO>>(_service.FindByAccelerationId(accelerationId.Value)));

                else
                    return Ok(_mapper.Map<List<CandidateDTO>>(_service.FindByCompanyId(companyId.Value)));
        }

        // POST api/candidate
        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
           
            var entity = _mapper.Map<Candidate>(value);
            var result = _service.Save(entity);
            var entityDTO = _mapper.Map<CandidateDTO>(result);
            return Ok(entityDTO);
        }


    }
}
