using fitness_tracker_api.Models;
using System.Collections.Generic;

namespace fitness_tracker_api.Repository
{
    public interface IExerciseRepo
    {
        public IEnumerable<ExerciseModel> GetAllExercises();

        public ExerciseModel GetExerciseById(string id);
    }
}