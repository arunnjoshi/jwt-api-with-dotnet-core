using System;
namespace fitness_tracker_api.Models
{
	public class ExerciseHistoryModel
	{
		public string userId { get; set; }
		public string exerciseName { get; set; }
		public string status { get; set; }
		public int caloriesBurn { get; set; }
		public int duration { get; set; }
		public DateTime time { get; set; }
	}
}