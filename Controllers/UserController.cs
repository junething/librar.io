using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LibrarioAPI.Services;
using LibrarioAPI.Models;

namespace LibrarioAPI.Controllers {
	[Route ("api/u")]
	[ApiController]
	public class UserController : ControllerBase {
		private readonly UserService _userService;

		public UserController (UserService userService)
		{
			_userService = userService;
		}
		[HttpPost ("signup")]
		public ActionResult<User>  Signup ([FromBody]UserSignup _user)
		{
			User user = _userService.CreateFrom(_user);
			return user;
		}
		[HttpPost ("login")]
		public ActionResult<string> Login ([FromBody]Credentials _user)
		{
			string token = _userService.Login(_user);
			return token;
		}
	}
}
