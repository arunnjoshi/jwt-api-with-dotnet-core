using Newtonsoft.Json;

namespace fitness_tracker_api.Models
{
    public class UserModel
    {
        public string token { get; set; }
        public string emailId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
}