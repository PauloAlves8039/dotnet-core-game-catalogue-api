using GameCatalogue.Application.DTOs;
using GameCatalogue.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameCatalogue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformDto>>> Get() 
        {
            var platforms = await _platformService.GetPlatforms();

            if (platforms == null) 
            {
                return NotFound("Platforms not found!");
            }

            return Ok(platforms);
        }

        [HttpGet("{id:int}", Name = "GetPlatform")]
        public async Task<ActionResult<PlatformDto>> Get(int id) 
        {
            var platform = await _platformService.GetById(id);

            if (platform == null)
            {
                return NotFound("Platform not found!");
            }

            return Ok(platform);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]PlatformDto platformDto) 
        {
            if (platformDto == null)
                return BadRequest("Invalid Data!");

            await _platformService.Add(platformDto);

            return new CreatedAtRouteResult("GetPlatform", new { id = platformDto.Id }, platformDto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PlatformDto platformDto) 
        {
            if (id != platformDto.Id)
                return BadRequest();

            if (platformDto == null)
                return BadRequest();

            await _platformService.Update(platformDto);

            return Ok(platformDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PlatformDto>> Delete(int id) 
        {
            var platform = await _platformService.GetById(id);

            if (platform == null) 
            {
                return NotFound("Platform not found!");
            }

            await _platformService.Remove(id);

            return Ok(platform);
        }

    }
}
