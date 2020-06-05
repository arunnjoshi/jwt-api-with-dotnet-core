using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace fitness_tracker_api.Controllers
{
    [ApiController]
    [Route("API/")]
    [Authorize]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepo _repo;

        public ExerciseController(IExerciseRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("exercises")]
        public ActionResult<IEnumerable<ExerciseModel>> GetAllExercises()
        {
            var exercises = _repo.GetAllExercises();
            return Ok(exercises);
        }

        [HttpGet("exercise/{id}")]
        public ActionResult<ExerciseModel> GetExerciseById(string id)
        {
            var exercise = _repo.GetExerciseById(id);
            if (exercise != null)
            {
                return Ok(exercise);
            }
            return NotFound();
        }
    }
}