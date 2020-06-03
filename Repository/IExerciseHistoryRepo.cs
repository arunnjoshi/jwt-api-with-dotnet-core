using System.Collections.Generic;
using fitness_tracker_api.Models;

namespace fitness_tracker_api.Repository
{
      public interface IExerciseHistoryRepo
      {
            public IEnumerable<ExerciseHistoryModel> GetPastExercises(string id);
      }
}