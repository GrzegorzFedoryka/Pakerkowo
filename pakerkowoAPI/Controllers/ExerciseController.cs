using Microsoft.AspNetCore.Mvc;
using PakerkowoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Controllers
{
    [Route("exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService service)
        {
            _exerciseService = service;
        }
        [HttpGet]
        public IActionResult GetById([FromRoute] int id)
        {
            var exercise = _exerciseService.GetById(id);

            return Ok(exercise.Result);
        }
    }
}
