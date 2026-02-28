namespace GYM
{
	public class Member
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public decimal Payment { get; set; }
		public bool IsDelete { get; set; } = false;

		public int? TrainerId { get; set; }
		public Trainer? Trainer { get; set; }
	}
}