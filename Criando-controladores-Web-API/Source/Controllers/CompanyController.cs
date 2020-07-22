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
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/company/{id}
        [HttpGet("{id}")]
        public ActionResult<CompanyDTO> Get(int id)
        {
            return Ok(_mapper.Map<CompanyDTO>(_service.FindById(id)));

        }

        // GET api/company
        [HttpGet]
        public ActionResult<IEnumerable<CompanyDTO>> GetAll(int? accelerationId = null, int? userId =null)
        {
            if ((accelerationId is null && userId is null) || (accelerationId != null && userId != null))
                return NoContent();
            
            if (accelerationId is null)
                return Ok(_mapper.Map<List<CompanyDTO>>(_service.FindByUserId(userId.Value)));
            
                else
                    return Ok(_mapper.Map<List<CompanyDTO>>(_service.FindByAccelerationId(accelerationId.Value)));
            
        }

        // POST api/company
        [HttpPost]
        public ActionResult<CompanyDTO> Post([FromBody] CompanyDTO value)
        {
           

            var entity = _mapper.Map<Company>(value);
            var result = _service.Save(entity);
            var entityDTO = _mapper.Map<CompanyDTO>(result);
            return Ok(entityDTO);
        }
    }
}
