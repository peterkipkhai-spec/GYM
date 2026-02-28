namespace GYM
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dataGridView1 = new DataGridView();
			btnAdd = new Button();
			btnDelete = new Button();
			comboBox1 = new ComboBox();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// dataGridView1
			// 
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(626, 12);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 82;
			dataGridView1.Size = new Size(162, 300);
			dataGridView1.TabIndex = 0;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(39, 275);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(150, 46);
			btnAdd.TabIndex = 1;
			btnAdd.Text = "Add";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(320, 275);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(150, 46);
			btnDelete.TabIndex = 2;
			btnDelete.Text = "Delete";
			btnDelete.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(55, 214);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(242, 40);
			comboBox1.TabIndex = 3;
			comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(55, 47);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(200, 39);
			textBox1.TabIndex = 4;
			textBox1.TextChanged += textBox1_TextChanged;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(55, 137);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(200, 39);
			textBox2.TabIndex = 5;
			textBox2.TextChanged += textBox2_TextChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(comboBox1);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(dataGridView1);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dataGridView1;
		private Button btnAdd;
		private Button button1;
		private Button btnDelete;
		private ComboBox comboBox1;
		private TextBox textBox1;
		private TextBox textBox2;
	}
}
