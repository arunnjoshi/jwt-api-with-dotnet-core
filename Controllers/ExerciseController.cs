
using System.Collections.Generic;
using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_api.Controllers
{

	[ApiController]
	[Route("api/exercises")]
	public class ExerciseController : ControllerBase
	{
		private readonly IExerciseRepo _repo;

		public ExerciseController(IExerciseRepo repo)
		{
			_repo = repo;
		}
		[HttpGet]
		public ActionResult<IEnumerable<ExerciseModel>> GetAllExercises()
		{
			var exercises = _repo.GetAllExercises();
			return Ok(exercises);
		}

		[HttpGet("{id}")]
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