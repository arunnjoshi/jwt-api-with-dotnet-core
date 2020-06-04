using fitness_tracker_api.Models;

namespace fitness_tracker_api.Repository
{
    public interface IAuthRepo
    {
        public UserModel Authenticate(string emailId,string password);
    }
}
