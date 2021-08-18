using System.Collections.Generic;
using System.Threading.Tasks;
using Altaliza.Domain.Entities;
using Altaliza.Domain.Repositories;
using Altaliza.Domain.Dtos;

namespace Altaliza.Domain.Services
{
    public class CharacterService
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<Character> CreateCharacter(CreateCharacterDto data)
        {
            var character = await _characterRepository.Create(new Character{
                Name = data.Name,
                Wallet = data.Wallet,
            });

            return character;
        }

        public async Task<List<Character>> ListAllCharacters()
        {
            var characters = await _characterRepository.FindAll();

            return characters;
        }
    }
}
