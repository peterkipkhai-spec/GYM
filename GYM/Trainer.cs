namespace GYM
{
	public class Trainer
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;

		public List<Member>? Members { get; set; }
	}
}