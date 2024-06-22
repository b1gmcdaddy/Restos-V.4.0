using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

namespace server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RestoController : ControllerBase
	{
		private ApplicationDbContext _context;

		public RestoController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public List<RestaurantEntity> GetAllRestos()
		{
			return _context.Restos.ToList();
		}

		[HttpGet("{id}")]
		public ActionResult<RestaurantEntity> GetRestoById(int id)
		{
			var resto = _context.Restos.Find(id);
			if(resto == null)
			{
				return NotFound();
			}
			return resto;
		}

		[HttpPost]
		public ActionResult<RestaurantEntity> AddResto(RestaurantEntity resto)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_context.Restos.Add(resto);
			_context.SaveChanges();

			return Ok(resto);
		}

		[HttpPut("{id}")]
		public ActionResult<RestaurantEntity> EditResto(int id,  RestaurantEntity resto)
		{
			var existingResto = _context.Restos.Find(id);

			if(existingResto == null)
			{
				return NotFound();
			}

			existingResto.Resto = resto.Resto;
			existingResto.Type = resto.Type;
			existingResto.Rating = resto.Rating;
			existingResto.IsVisited = resto.IsVisited;
			existingResto.Description = resto.Description;

			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public ActionResult DeleteResto(int id)
		{
			var resto = _context.Restos.Find(id);
			if(resto == null)
			{
				return NotFound();
			}
			_context.Restos.Remove(resto);
			_context.SaveChanges();

			return NoContent();
		}
	}
}
