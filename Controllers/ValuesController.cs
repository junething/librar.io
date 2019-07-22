using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LibrarioAPI.Services;
using LibrarioAPI.Models;

namespace LibrarioAPI.Controllers {
	[Route ("api/values")]
	[ApiController]
	public class ValuesController : ControllerBase {
		private readonly ValueService _valueService;

		public ValuesController (ValueService valueService)
		{
			_valueService = valueService;
		}
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get ()
		{
			return new string [] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet ("{id}")]
		public ActionResult<string> Get (int id)
		{
			return id.ToString();
		}

		// POST api/values
		[HttpPost]
		public IActionResult Post ([FromBody] string value)
		{
			_valueService.Create (new Value (value));

			return NoContent ();

		}

		// PUT api/values/5
		[HttpPut ("{id}")]
		public ActionResult<string> Put (int id, [FromBody] string value)
		{
			return value;
		}

		// DELETE api/values/5
		[HttpDelete ("{id}")]
		public void Delete (int id)
		{
		}
	}
}
