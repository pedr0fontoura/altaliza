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

        public async Task<DomainResponseDto<Character>> CreateCharacter(CreateCharacterDto data)
        {
            var response = new DomainResponseDto<Character>();

            var character = await _characterRepository.Create(new Character{
                Name = data.Name,
                Wallet = data.Wallet,
            });

            response.Data = character;

            return response;
        }

        public async Task<DomainResponseDto<Character>> ShowCharacter(int id)
        {
            var response = new DomainResponseDto<Character>();

            var character = await _characterRepository.FindById(id);

            if (character == null)
            {
                response.AddError("characterId", "Personagem não encontrado");
            }

            if (!response.HasErrors())
            {
                response.Data = character;
            }

            return response;
        }

        public async Task<DomainResponseDto<List<Character>>> ListCharacters()
        {
            var response = new DomainResponseDto<List<Character>>();

            var characters = await _characterRepository.FindAll();

            response.Data = characters;

            return response;
        }
    }
}
