using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryOfficeAPI.Entities;
using VeterinaryOfficeAPI.Models;

namespace VeterinaryOfficeAPI
{
    public class VeterinaryOfficeMappingProfile : Profile
    {
        public VeterinaryOfficeMappingProfile()
        {
            CreateMap<CreateAnimalDto, Animal>()
                .ForMember(x => x.Owner, c => c.MapFrom(dto => new Owner()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    PhoneNumber = dto.PhoneNumber
                }))
                .ForMember(x => x.Visit, c => c.MapFrom(dto => new Visit()
                {
                    FirstVisit = dto.FirstVisit,
                    LastVisit = dto.LastVisit
                }));
            CreateMap<Animal, AnimalDto>()
                .ForMember(m => m.FirstName, c => c.MapFrom(s => s.Owner.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(s => s.Owner.LastName))
                .ForMember(m => m.PhoneNumber, c => c.MapFrom(s => s.Owner.PhoneNumber))
                .ForMember(m => m.FirstVisit, c => c.MapFrom(s => s.Visit.FirstVisit))
                .ForMember(m => m.LastVisit, c => c.MapFrom(s => s.Visit.LastVisit));
        }
    }
}
