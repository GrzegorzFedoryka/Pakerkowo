using AutoMapper;
using PakerkowoAPI.Entities;
using PakerkowoAPI.Exceptions;
using PakerkowoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Services
{
    public interface IExerciseService
    {
        ExerciseDto GetById(int id);
    }

    public class ExerciseService : IExerciseService
    {
        private readonly PakerkowoDbContext _dbContext;
        private readonly IMapper _mapper;

        public ExerciseService(PakerkowoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ExerciseDto GetById(int id)
        {
            var exercise = _dbContext
                                .Exercises
                                .FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                throw new NotFoundException("Exercise not found!");
            }
            var result = _mapper.Map<ExerciseDto>(exercise);
            return result;
        }
    }
}
