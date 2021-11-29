using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_net_course_udemy.Dtos.Character;
using asp_net_course_udemy.Models;
using AutoMapper;
using dot_net_role_playing_game.Data;
using Microsoft.EntityFrameworkCore;

namespace asp_net_course_udemy.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _DbContext;
        public CharacterService(IMapper mapper, DataContext dbContext)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Name = "Sam", Id = 1}
        };
        public async Task<GeneralResponse<object>> AddCharacter(AddCharacterDTO newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(element => element.Id) + 1;
            characters.Add(character);
            return new GeneralResponse<object>();
        }

        public async Task<List<GetCharacterDTO>> GetAllCharacters()
        {
            var dbCharacters = await _DbContext.Characters.ToListAsync();
            return dbCharacters.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
        }


        public async Task<GetCharacterDTO> GetCharacterById(int id)
        {
            var dbSingleCharacter = await _DbContext.Characters.FirstOrDefaultAsync<Character>(c=>c.Id == id);
            return _mapper.Map<GetCharacterDTO>(dbSingleCharacter);
        }

        public async Task<GeneralResponse<object>> UpdateCharacter(UpdateCharacterDTO updatedCharacter)
        {
            try
            {
                Character character = characters.FirstOrDefault(element => element.Id == updatedCharacter.Id);
                character.Name = updatedCharacter.Name;
                character.HitPoints = updatedCharacter.HitPoints;
                character.Strength = updatedCharacter.HitPoints;
                character.Defence = updatedCharacter.Defence;
                character.Intelligence = updatedCharacter.Intelligence;
                return new GeneralResponse<object>();
            }
            catch (Exception e)
            {
                GeneralResponse<object> resp = new GeneralResponse<object>();
                resp.IsSuccess = false;
                resp.errorMessage = e.Message;
                return resp;
            }

        }

        public async Task<GeneralResponse<object>> DeleteCharacter(int id)
        {
            GeneralResponse<object> response = new GeneralResponse<object>();
            try
            {
                Character character = characters.First(character => character.Id == id);
                characters.Remove(character);
                return response;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.errorMessage = e.Message;
                return response;
            }

        }

    }
}