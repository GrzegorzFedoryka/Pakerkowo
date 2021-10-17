using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public Task<Exercise> GetById(int id);
    }

    public class ExerciseService : IExerciseService
    {
        private readonly PakerkowoDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ExerciseService(PakerkowoDbContext dbContext, ILogger<ExerciseService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task Add(ExerciseDto dto)
        {

        }

        public async Task<Exercise> GetById(int id)
        {
            var exercise = await _dbContext.Exercises.FirstOrDefaultAsync(e => e.Id == id);
            return exercise;
        }
    }
}
