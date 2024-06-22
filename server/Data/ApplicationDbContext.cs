using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<RestaurantEntity> Restos { get; set; }
	}
}
