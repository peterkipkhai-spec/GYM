
using System.Xml.Linq;
using GYM;
using Microsoft.EntityFrameworkCore;

namespace GymWinFormsApp
{
	public partial class MainForm : Form
	{
		private GymDbContext _context = new GymDbContext();
		private object dgvMembers;

		public MainForm()
		{
			InitializeComponent();
			LoadTrainers();
			LoadMembers();
		}

		private void InitializeComponent()
		{
			throw new NotImplementedException();
		}

		private void LoadMembers()
		{
			dgvMembers.DataSource = _context.Members
				.Include(x => x.Trainer)
				.Where(x => !x.IsDelete)
				.Select(x => new
				{
					x.Id,
					x.Name,
					x.Payment,
					Trainer = x.Trainer.Name
				})
				.ToList();
		}

		private void LoadTrainers()
		{
			cmbTrainer.DataSource = _context.Trainers.ToList();
			cmbTrainer.DisplayMember = "Name";
			cmbTrainer.ValueMember = "Id";
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var member = new Member
			{
				Name = txtName.Text,
				Payment = decimal.Parse(txtPayment.Text),
				TrainerId = (int)cmbTrainer.SelectedValue
			};

			_context.Members.Add(member);
			_context.SaveChanges();
			LoadMembers();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvMembers.CurrentRow == null) return;

			int id = (int)dgvMembers.CurrentRow.Cells["Id"].Value;

			var member = _context.Members.Find(id);
			member.IsDelete = true;

			_context.SaveChanges();
			LoadMembers();
		}
	}

	internal class GymDbContext
	{
		internal object Members;

		public GymDbContext()
		{
		}

		internal void SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}