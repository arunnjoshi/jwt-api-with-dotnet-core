using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using System.Collections.Generic;
using System.Linq;

namespace fitness_tracker_api.Data
{
    public class ExerciseData : IExerciseRepo
    {
        private IEnumerable<ExerciseModel> exercises = new List<ExerciseModel> {
                        new ExerciseModel { id = "leg", name = "leg", duration = 60, calories = 120 },
                        new ExerciseModel { id = "lunges", name = "Lunges", duration = 60, calories = 150 },
                        new ExerciseModel { id = "cross-punches", name = "Cross Punches", duration = 60, calories = 130 }
                     };

        public IEnumerable<ExerciseModel> GetAllExercises()
        {
            return this.exercises;
        }

        public ExerciseModel GetExerciseById(string id)
        {
            var exercise = this.exercises.FirstOrDefault(e => e.id == id);
            return (exercise);
        }
    }
}