using fitness_tracker_api.Models;
using fitness_tracker_api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_api.Controllers
{
	[Route("api/user/")]

	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepo _authRepo;

		public AuthController(IAuthRepo authRepo)
		{
			_authRepo = authRepo;
		}
		[HttpPost]
		public ActionResult<UserModel> Login([FromBody] UserModel userPost)
		{
			// var user = _authRepo.Authenticate(userPost.emailId, userPost.password);
			// if (user != null)
			// {
			// 	return Ok(user);
			// }
			return NotFound("not found any user");
		}
	}
}