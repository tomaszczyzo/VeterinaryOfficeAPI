using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryOfficeAPI.Entities;
using VeterinaryOfficeAPI.Models;

namespace VeterinaryOfficeAPI.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly VeterinaryOfficeDbContext _dbContext;
        private readonly IMapper _mapper;

        public AnimalService(VeterinaryOfficeDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnimalDto>> GetAll()
        {
            var animals = await _dbContext
                .Animals
                .AsQueryable()
                .Include(r => r.Owner)
                .Include(r => r.Visit)
                .ToListAsync();

            var result = _mapper.Map<List<AnimalDto>>(animals);

            return result;
        }
        public async Task<AnimalDto> GetById(int id)
        {
            var animal = await _dbContext
                .Animals
                .Include(r => r.Owner)
                .Include(r => r.Visit)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (animal is null)
                throw new Exception("Animal not found");

            var result = _mapper.Map<AnimalDto>(animal);

            return result;
        }
        public async Task<int> Create(CreateAnimalDto dto)
        {
            var exists = await _dbContext
                .Animals
                .Include(r => r.Owner)
                .FirstOrDefaultAsync(r => r.Owner.PhoneNumber == dto.PhoneNumber);
            
            var animal = _mapper.Map<Animal>(dto);
            if (exists != null)
            {
                animal.Owner = exists.Owner;
            }
            await _dbContext.Animals.AddAsync(animal);
            await _dbContext.SaveChangesAsync();


            return animal.Id;
        }
        public async Task Update(int id, CreateAnimalDto dto)
        {
            var animal = await _dbContext
                .Animals
                .Include(r => r.Owner)
                .Include(r => r.Visit)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (animal is null)
                throw new Exception("Animal not found");

            animal.Species = dto.Species;
            animal.Breed = dto.Breed;
            animal.Name = dto.Name;
            animal.DateOfBirth = dto.DateOfBirth;
            animal.Color = dto.Color;
            animal.Size = dto.Size;
            animal.Weight = dto.Weight;
            animal.Owner.FirstName = dto.FirstName;
            animal.Owner.LastName = dto.LastName;
            animal.Owner.PhoneNumber = dto.PhoneNumber;
            animal.Visit.FirstVisit = dto.FirstVisit;
            animal.Visit.LastVisit = dto.LastVisit;

            await _dbContext.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            var animal = await _dbContext
                .Animals
                .FirstOrDefaultAsync(r => r.Id == id);

            if (animal is null)
                throw new Exception("Animal not found");

            _dbContext.Animals.Remove(animal);
            await _dbContext.SaveChangesAsync();
        }
    }
}
