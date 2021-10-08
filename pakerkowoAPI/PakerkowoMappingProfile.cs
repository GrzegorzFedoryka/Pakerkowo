using AutoMapper;
using PakerkowoAPI.Entities;
using PakerkowoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI
{
    public class PakerkowoMappingProfile : Profile
    {
        public PakerkowoMappingProfile()
        {
            CreateMap<Exercise, ExerciseDto>()
                .ForMember(d => d.BodyParts, c => c.MapFrom(s => s.BodyParts.Select(b => b.Name).ToArray()));
        }
    }
}
