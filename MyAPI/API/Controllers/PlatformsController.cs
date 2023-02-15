using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
          private readonly IPlatformRepo _repository;

        public PlatformsController(IPlatformRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PLatform>> GetPlatforms()
        {
            return Ok(_repository.GetAllPlatforms());
        }

        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<IEnumerable<PLatform>> GetPlatformById(string id)
        {
            
            var platform = _repository.GetPlatformById(id);
            
            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult <PLatform> CreatePlatform(PLatform platform)
        {
            _repository.CreatePlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformById), new {Id = platform.Id}, platform);
        }
    }
}