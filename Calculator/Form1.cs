using System.Data;
using org.mariuszgromada.math.mxparser;

namespace Calculator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		public bool on = true;
		public bool set_2nd = false;

		private void Form1_Load(object sender, EventArgs e)
		{
			foreach (Button button in groupBox1.Controls)
			{
				button.Enabled = false;
			}
			buttonOnOff.Enabled = true;
			on = !on;
		}

		private void changebuttons()
		{
			if (!set_2nd)
			{
				buttonSin.Text = "sin()";
				buttonCos.Text = "cos()";
				buttonTan.Text = "tan()";
				buttonLGLN.Text = "log(,)";
				buttonPow.Text = "^2";
			}
			else
			{
				buttonSin.Text = "arcsin()";
				buttonCos.Text = "arccos()";
				buttonTan.Text = "arctan()";
				buttonLGLN.Text = "ln()";
				buttonPow.Text = "^";
			}
		}
		// Changes the text of certain buttons ^

		private void buttonEquals_Click(object sender, EventArgs e)
		{
			// var result = new DataTable().Compute(richTextBox1.Text, null);
			// label1.Text = result.ToString();
			var result = new Expression(richTextBox1.Text).calculate();
			label1.Text = result.ToString();
			// Easier way to calculate what's written in the textbox
			
			/*
			 * I downloaded this library mostly because i didn't really feel like doing it myself and to make it a lot easier.
			 * The person who made this did an absolutely amazing work.
			 */

		}
		// Calculates the text in the textbox and prints the answer in the label ^

		private void mouse_click(object sender, EventArgs e)
		{
			var button = (Button)sender;
			richTextBox1.Text += button.Text;
		}
		// Gets the text of the buttons ^

		private void button2nd_Click(object sender, EventArgs e)
		{
			if (!set_2nd)
			{
				button2nd.BackColor = SystemColors.AppWorkspace;
				set_2nd = true;
			}
			else if (set_2nd)
			{
				button2nd.BackColor = SystemColors.Control;
				set_2nd = false;
			}
			changebuttons();
		}

		private void buttonOnOff_Click(object sender, EventArgs e)
		{
			foreach (Button button in groupBox1.Controls)
			{
				button.Enabled = !on;
			}
			buttonOnOff.Enabled = true;
			on = !on;
		}

		private void buttonC_Click(object sender, EventArgs e)
		{
			richTextBox1.ResetText();
		}
        // Clear button ^
    }
}
