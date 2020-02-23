using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoWorker
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.Visible = false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timer.Enabled = true;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			
		}
	}
}
