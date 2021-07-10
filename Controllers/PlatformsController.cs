using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Comandos.Data;
using Comandos.Models;
using Microsoft.AspNetCore.Mvc;
using Comandos.Dtos;
using AutoMapper;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            return _platformRepo.GetAllPlatforms().ToList();
        }

        // GET api/platform/1
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(int id)
        {
            var platFormFound = _platformRepo.GetPlatformById(id);
            if(platFormFound == null) return NotFound();

            return Ok(platFormFound);
        }

        // POST api/platform/
        [HttpPost]
        public ActionResult Post( PlatformCreateDto platformCreate )
        {
            var newPlaform = _mapper.Map<Platform>(platformCreate);
            _platformRepo.CreatePlatform(newPlaform);
            _platformRepo.SaveChanges();

              var objToReturn =  new {
                Id= newPlaform.PlatformId,
            };
            return CreatedAtRoute(nameof(GetPlatformById), objToReturn, newPlaform);

        }

    }
}