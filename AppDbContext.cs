using Microsoft.EntityFrameworkCore;
using Airline.Models;

namespace Airline
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Airlines> Airlines { get; set; }
		public DbSet<Flights> Flights { get; set; }
	}
}
