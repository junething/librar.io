using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LibrarioAPI.Services;
using LibrarioAPI.Models;

namespace LibrarioAPI.Controllers {
	[Route ("api/i")]
	[ApiController]
	public class ItemsController : ControllerBase {
		private readonly ItemService _itemService;

		public ItemsController (ItemService itemService)
		{
			_itemService = itemService;
		}
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<Item>> Get ()
		{
			//return new string [] { "value1", "value2" };
			return _itemService.Get ();
		}

		[HttpGet ("{id}", Name = "GetItem")]
		public ActionResult<Item> Get (string id)
		{
			var item = _itemService.Get (id);

			if (item == null) {
				return NotFound ();
			}

			return item;
		}

		[HttpGet ("new")]
		public ActionResult<Item> New ()
		{
			Item item = new Item ();
			item.Title = "It's a me!";
			item.Creator = "Mario";
			item.Sources = new Dictionary<string, Source> { { "YouTube", new Source ("ob9TxO5jO5s", new[] { "everyone" }) }, { "PeerTube", new Source ("c7d0284d-8a86-45b1-abaf-825fda118bc1", new[] { "everyone" }) } };
			_itemService.Create (item);
			return item;
		}

		[HttpPut ("{id}")]
		public IActionResult Update (string id, Item itemIn)
		{
			var item = _itemService.Get (id);

			if (item == null) {
				return NotFound ();
			}

			_itemService.Update (id, itemIn);

			return NoContent ();
		}

		[HttpDelete ("{id}")]
		public IActionResult Delete (string id)
		{
			var item = _itemService.Get (id);

			if (item == null) {
				return NotFound ();
			}

			_itemService.Remove (item.Id);

			return NoContent ();
		}
	}
}
