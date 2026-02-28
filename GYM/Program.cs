using System.Linq;

namespace GYM
{
	internal static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var db = new GymDbContext())
			{
				db.Database.EnsureCreated();

				if (!db.Trainers.Any())
				{
					db.Trainers.AddRange(
						new Trainer { Name = "John" },
						new Trainer { Name = "Mike" }
					);
					db.SaveChanges();
				}
			}

			ApplicationConfiguration.Initialize();
			Application.Run(new MainForm());
		}
	}

	internal class GymDbContext : IDisposable
	{
		public object Database { get; internal set; }
	}
}