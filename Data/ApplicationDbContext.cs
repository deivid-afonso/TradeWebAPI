namespace TradeWebAPI.Data
{
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Reflection.Emit;
	using TradeWebAPI.Models;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Trade> Trades { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}

}
