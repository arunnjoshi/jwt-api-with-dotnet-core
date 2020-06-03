using System.ComponentModel.DataAnnotations;
namespace fitness_tracker_api.Models
{
      public class ExerciseModel
      {
            [Required]
            public string id { get; set; }

            [Required]
            public string name { get; set; }

            [Required]
            public int duration { get; set; }

            [Required]
            public int calories { get; set; }

      }
}