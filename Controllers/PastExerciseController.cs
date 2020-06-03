using System.Net;
using System.Diagnostics;
using System.Collections.Generic;
using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace fitness_tracker_api.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/pastExercises")]
	public class PastExerciseController : ControllerBase
	{
		private readonly IExerciseHistoryRepo _repo;

		public PastExerciseController(IExerciseHistoryRepo repo)
		{
			_repo = repo;
		}
		[HttpGet("{id}")]
		public ActionResult<IEnumerable<ExerciseHistoryModel>> GetPastExercises(string id)
		{
			var exercises = _repo.GetPastExercises(id);
			return Ok(exercises);
		}

		[HttpPost]
		public ActionResult<ExerciseHistoryModel> PutExercise([FromBody] ExerciseHistoryModel exercise)
		{
			return (exercise);
		}
	}
}