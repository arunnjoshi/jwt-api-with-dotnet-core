using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_api.Controllers
{
    [ApiController]
    [Route("API/user/")]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepo authRepo;

        public UserController(IAuthRepo authRepo)
        {
            this.authRepo = authRepo;
        }

        [HttpPost("login")]
        public ActionResult<UserModel> Login([FromBody] UserModel userModel)
        {
            var user = authRepo.Authenticate(userModel.emailId, userModel.password);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("not found any user");
        }
    }
}