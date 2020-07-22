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
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAll(string accelerationName = null, int? companyId = null)
        {
            if ((accelerationName is null && companyId is null) || (accelerationName != null && companyId != null))
                return NoContent();

            if (companyId is null)
                return Ok(_mapper.Map<List<UserDTO>>(_service.FindByAccelerationName(accelerationName)));

            else
                return Ok(_mapper.Map<List<UserDTO>>(_service.FindByCompanyId(companyId.Value)));


        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            return Ok(_mapper.Map<UserDTO>(_service.FindById(id)));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
           

            var entity = _mapper.Map<User>(value);
            var result = _service.Save(entity);
            var entityDTO = _mapper.Map<UserDTO>(result);
            return Ok(entityDTO);
        }   
     
    }
}
