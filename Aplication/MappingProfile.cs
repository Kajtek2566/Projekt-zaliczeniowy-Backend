using Domain.DTO;
using Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Animal, AnimalDTO>();
            CreateMap<AnimalDTO, Animal>();

           
            CreateMap<ZooUser, ZooUserDTO>();
            CreateMap<ZooUserDTO, ZooUser>();

            CreateMap<AnimalSponsor, AnimalSponsorDTO>();
            CreateMap<AnimalSponsorDTO, AnimalSponsor>();
        }
    }
}

