using Microsoft.EntityFrameworkCore;

namespace GYM
{
	public class GymDbContext : DbContext
	{
		public DbSet<Member> Members { get; set; }
		public DbSet<Trainer> Trainers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite("Data Source=gym.db");
		}
	}
}