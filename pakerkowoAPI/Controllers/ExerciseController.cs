using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Controllers
{
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        //private readonly IExerciseService _exerciseService;
        //public ExerciseController(IExerciseService service)
        //{
        //        _exerciseService = service;
        //}

        public IActionResult GetById([FromRoute] int id)
        {
            //var exercise = _exerciseService.GetById(id);

            return Ok();
        }
    }
}
