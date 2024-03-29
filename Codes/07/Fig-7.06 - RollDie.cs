// Fig. 7.6: RollDie.cs
// Lançamento de 12 dados.

using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

partial class RollDie : Form
{
	private Button rollButton;

	private RichTextBox displayTextBox;

	private Label dieLabel1; private Label dieLabel2;
	private Label dieLabel3; private Label dieLabel4;
	private Label dieLabel5; private Label dieLabel6;
	private Label dieLabel7; private Label dieLabel8;
	private Label dieLabel9; private Label dieLabel10;
	private Label dieLabel11; private Label dieLabel12;

	Random randomNumber = new Random();
	int[] frequency = new int[7];

	private void InitializeComponent()
	{
		this.displayTextBox = new RichTextBox();

		this.rollButton = new Button();

		this.dieLabel1 = new Label();
		this.dieLabel2 = new Label();
		this.dieLabel3 = new Label();
		this.dieLabel4 = new Label();
		this.dieLabel5 = new Label();
		this.dieLabel6 = new Label();
		this.dieLabel7 = new Label();
		this.dieLabel8 = new Label();
		this.dieLabel9 = new Label();
		this.dieLabel10 = new Label();
		this.dieLabel11 = new Label();
		this.dieLabel12 = new Label();

		// displayTextBox.
		this.displayTextBox.Name = "displayTextBox";
		this.displayTextBox.Text = "";
		this.displayTextBox.Size = new Size(280, 130);
		this.displayTextBox.Location = new Point(10, 110);

		// rollButton.
		this.rollButton.Name = "rollButton";
		this.rollButton.Text = "Roll";
		this.rollButton.AutoSize = true;
		this.rollButton.Location = new Point(10, 70);
		this.rollButton.Click += new EventHandler(rollButton_Click);

		// dieLabel1.
		this.dieLabel1.Name = "dieLabel1";
		this.dieLabel1.Text = "";
		this.dieLabel1.AutoSize = true;
		this.dieLabel1.Location = new Point(10, 10);

		// dieLabel2.
		this.dieLabel2.Name = "dieLabel2";
		this.dieLabel2.Text = "";
		this.dieLabel2.AutoSize = true;
		this.dieLabel2.Location = new Point(40, 10);

		// dieLabel3.
		this.dieLabel3.Name = "dieLabel3";
		this.dieLabel3.Text = "";
		this.dieLabel3.AutoSize = true;
		this.dieLabel3.Location = new Point(70, 10);

		// dieLabel4.
		this.dieLabel4.Name = "dieLabel4";
		this.dieLabel4.Text = "";
		this.dieLabel4.AutoSize = true;
		this.dieLabel4.Location = new Point(100, 10);

		// dieLabel5.
		this.dieLabel5.Name = "dieLabel5";
		this.dieLabel5.Text = "";
		this.dieLabel5.AutoSize = true;
		this.dieLabel5.Location = new Point(130, 10);

		// dieLabel6.
		this.dieLabel6.Name = "dieLabel6";
		this.dieLabel6.Text = "";
		this.dieLabel6.AutoSize = true;
		this.dieLabel6.Location = new Point(160, 10);

		// dieLabel7.
		this.dieLabel7.Name = "dieLabel7";
		this.dieLabel7.Text = "";
		this.dieLabel7.AutoSize = true;
		this.dieLabel7.Location = new Point(10, 40);

		// dieLabel8.
		this.dieLabel8.Name = "dieLabel8";
		this.dieLabel8.Text = "";
		this.dieLabel8.AutoSize = true;
		this.dieLabel8.Location = new Point(40, 40);

		// dieLabel9.
		this.dieLabel9.Name = "dieLabel9";
		this.dieLabel9.Text = "";
		this.dieLabel9.AutoSize = true;
		this.dieLabel9.Location = new Point(70, 40);

		// dieLabel10.
		this.dieLabel10.Name = "dieLabel10";
		this.dieLabel10.Text = "";
		this.dieLabel10.AutoSize = true;
		this.dieLabel10.Location = new Point(100, 40);

		// dieLabel11.
		this.dieLabel11.Name = "dieLabel11";
		this.dieLabel11.Text = "";
		this.dieLabel11.AutoSize = true;
		this.dieLabel11.Location = new Point(130, 40);

		// dieLabel12.
		this.dieLabel12.Name = "dieLabel12";
		this.dieLabel12.Text = "";
		this.dieLabel12.AutoSize = true;
		this.dieLabel12.Location = new Point(160, 40);

		// RollDie2.
		this.Controls.AddRange(new Control[]{
			this.displayTextBox, this.rollButton,
			this.dieLabel1, this.dieLabel2,
			this.dieLabel3, this.dieLabel4,
			this.dieLabel5, this.dieLabel6,
			this.dieLabel7, this.dieLabel8,
			this.dieLabel9, this.dieLabel10,
			this.dieLabel11, this.dieLabel12,
		});
		this.Name = "RollDie";
		this.Text = "RollDie";
		this.AutoSize = true;
		this.ResumeLayout(false);
	}

	protected void rollButton_Click(object? sender, EventArgs e)
	{
		DisplayDie(dieLabel1); DisplayDie(dieLabel2);
		DisplayDie(dieLabel3); DisplayDie(dieLabel4);
		DisplayDie(dieLabel5); DisplayDie(dieLabel6);
		DisplayDie(dieLabel7); DisplayDie(dieLabel8);
		DisplayDie(dieLabel9); DisplayDie(dieLabel10);
		DisplayDie(dieLabel11); DisplayDie(dieLabel12);

		double total = 0;

		for (int i = 1; i < 7; i++)
			total += frequency[i];

		displayTextBox.Text = "Face\tFrequency\tPercent\n";

		for (int x = 1; x < frequency.Length; x++)
		{
			displayTextBox.Text +=
				x + "\t" + frequency[x] + "\t\t" +
				String.Format("{0:N}", frequency[x] / total * 100) +
				"%\n";
		}
	}

	public void DisplayDie(Label dieLabel)
	{
		int face = randomNumber.Next(1, 7);

		dieLabel.Text = $"{face}";

		/* dieLabel.Image = Image.FromFile(
			Directory.GetCurrentDirectory() +
			"\\images\\die" + face + ".gif"
		); */

		frequency[face]++;
	}
}

partial class RollDie
{
	private Container? components = null;

	public RollDie()
	{ InitializeComponent(); }

	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{ components.Dispose(); }

		base.Dispose(disposing);
	}
}

static class Program
{
	[STAThread]
	static void Main()
	{
		ApplicationConfiguration.Initialize();
		Application.Run(new RollDie());
	}
}
