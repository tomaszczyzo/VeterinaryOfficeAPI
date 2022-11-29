using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryOfficeAPI.Entities;

namespace VeterinaryOfficeAPI
{
    public class VeterinaryOfficeSeeder
    {
        private readonly VeterinaryOfficeDbContext _dbContext;

        public VeterinaryOfficeSeeder(VeterinaryOfficeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Owners.Any())
                {
                    var owners = GetOwners();
                    _dbContext.Owners.AddRange(owners);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Animals.Any())
                {
                    var animals = GetAnimals();
                    _dbContext.Animals.AddRange(animals);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Animal> GetAnimals()
        {
            var animals = new List<Animal>()
            {
                new Animal()
                {
                    Species = "Cat",
                    Breed = "Abyssinian",
                    Name = "Daro",
                    DateOfBirth = new DateTime(2010, 6, 2),
                    Color = "Black",
                    Size = "Medium",
                    Weight = 15.3M,
                    OwnerId = 1,
                    Visit = new Visit()
                    {
                        FirstVisit = new DateTime(2019, 2, 5),
                        LastVisit = new DateTime(2020, 12, 3)
                    }
                },
                new Animal()
                {
                    Species = "Cat",
                    Breed = "Abyssinian",
                    Name = "Maro",
                    DateOfBirth = new DateTime(2012, 4, 2),
                    Color = "Black",
                    Size = "Small",
                    Weight = 19.3M,
                    OwnerId = 1,
                    Visit = new Visit()
                    {
                        FirstVisit = new DateTime(2020, 2, 5),
                        LastVisit = new DateTime(2021, 12, 3)
                    }
                },
                new Animal()
                {
                    Species = "Dog",
                    Breed = "Greyhound",
                    Name = "Pashko",
                    DateOfBirth = new DateTime(2014, 6, 2),
                    Color = "Black",
                    Size = "Medium",
                    Weight = 15.3M,
                    OwnerId = 2,
                    Visit = new Visit()
                    {
                        FirstVisit = new DateTime(2015, 2, 5),
                        LastVisit = new DateTime(2018, 12, 3)
                    }
                }
            };
            return animals;
        }
        private IEnumerable<Owner> GetOwners()
        {
            var owners = new List<Owner>()
            {
                new Owner()
                {
                    FirstName = "Mario",
                    LastName = "Yogo",
                    PhoneNumber = "123123123"
                },
                new Owner()
                {
                    FirstName = "Matty",
                    LastName = "Papu",
                    PhoneNumber = "999999999"
                }

            };
            return owners;
        }
    }
}
