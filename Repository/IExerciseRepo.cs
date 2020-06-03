using System.Collections.Generic;
using fitness_tracker_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_api.Repository
{
      public interface IExerciseRepo
      {
            public IEnumerable<ExerciseModel> GetAllExercises();
            public ExerciseModel GetExerciseById(string id);

      }
}