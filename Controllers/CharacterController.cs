using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_course_udemy.Dtos.Character;
using asp_net_course_udemy.Models;
using asp_net_course_udemy.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_course_udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GetCharacterDTO>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDTO>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("AddCharacter")]
        public async Task<ActionResult<GeneralResponse<object>>> AddNewCharacter(AddCharacterDTO newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut("UpdateCharacter")]
        public async Task<ActionResult<GeneralResponse<object>>> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            return Ok(await _characterService.UpdateCharacter(updateCharacter));
        }
        [HttpDelete("DeleteCharacter/{id}")]
        public async Task<ActionResult<GeneralResponse<object>>> DeleteCharacter(int id) 
        {
            return Ok(await _characterService.DeleteCharacter(id));
        }
    }
}