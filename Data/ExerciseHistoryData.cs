using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using System.Collections.Generic;
using System.Linq;

namespace fitness_tracker_api.Data
{
    public class ExerciseHistoryData : IExerciseHistoryRepo
    {
        public List<ExerciseHistoryModel> userPastExercises = new List<ExerciseHistoryModel> {
            new ExerciseHistoryModel{userId="arun",status="completed",caloriesBurn=120,duration=40,exerciseName="leg"} ,
            new ExerciseHistoryModel{userId="arun",status="cancelled",caloriesBurn=10,duration=4,exerciseName="arms"}
        };

        public IEnumerable<ExerciseHistoryModel> GetPastExercises(string id)
        {
            return this.userPastExercises.Where(e => e.userId == id).OrderBy(e => e.exerciseName);
        }
    }
}