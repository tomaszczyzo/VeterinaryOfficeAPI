using VeterinaryOfficeAPI.Entities;
using VeterinaryOfficeAPI.Models;

namespace VeterinaryOfficeAPI.Services
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDto>> GetAll();
        Task<AnimalDto> GetById(int id);
        Task<int> Create(CreateAnimalDto dto);
        Task Update(int id, CreateAnimalDto dto);
        Task Delete(int id);

    }
}