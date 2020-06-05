using fitness_tracker_api.Models;
using System.Collections.Generic;

namespace fitness_tracker_api.Repository
{
    public interface IExerciseHistoryRepo
    {
        public IEnumerable<ExerciseHistoryModel> GetPastExercises(string id);
    }
}