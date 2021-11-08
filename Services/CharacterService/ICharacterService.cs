using System.Collections.Generic;
using System.Threading.Tasks;
using asp_net_course_udemy.Dtos.Character;
using asp_net_course_udemy.Models;

namespace asp_net_course_udemy.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<List<GetCharacterDTO>> GetAllCharacters();
         Task<GetCharacterDTO> GetCharacterById(int id);
         Task<GeneralResponse<object>> AddCharacter(AddCharacterDTO newCharacter);
         Task<GeneralResponse<object>> UpdateCharacter(UpdateCharacterDTO updateCharacter);
         Task<GeneralResponse<object>> DeleteCharacter(int id);
    }
}