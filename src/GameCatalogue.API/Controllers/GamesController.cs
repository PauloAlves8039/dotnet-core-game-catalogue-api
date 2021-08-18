using GameCatalogue.Application.DTOs;
using GameCatalogue.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCatalogue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> Get() 
        {
            var games = await _gameService.GetGames();

            if (games == null) 
            {
                return NotFound("Games not found!");
            }

            return Ok(games);
        }

        [HttpGet("{id}", Name = "GetGame")]
        public async Task<ActionResult<GameDto>> Get(int id) 
        {
            var game = await _gameService.GetById(id);

            if (game == null) 
            {
                return NotFound("Game not found!");
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GameDto gameDto) 
        {
            if (gameDto == null)
                return BadRequest("Data Invalid!");

            await _gameService.Add(gameDto);

            return new CreatedAtRouteResult("GetGame", new { id = gameDto.Id }, gameDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] GameDto gameDto) 
        {
            if (id != gameDto.Id) 
            {
                return BadRequest("Invalid Data!");
            }

            if (gameDto == null)
                return BadRequest("Invalid Data!");

            await _gameService.Update(gameDto);

            return Ok(gameDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GameDto>> Delete(int id) 
        {
            var gameDto = await _gameService.GetById(id);

            if (gameDto == null) 
            {
                return NotFound("Game not found!");
            }

            await _gameService.Remove(id);

            return Ok(gameDto);
        }
    }
}
