using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutdownCountdown
{
	public partial class SettingForm : Form
	{
		public SettingForm()
		{
			InitializeComponent();
		}

		private void SettingForm_Load(object sender, EventArgs e)
		{
			var t = DateTime.Now + TimeSpan.FromMinutes(60);
			var timeToShutdown = new DateTime(t.Year, t.Month, t.Day, t.Hour, t.Minute, second: 0, millisecond: 0);
			dateTimePicker.Value = timeToShutdown;
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void okBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			Program.TimeToShutdown = dateTimePicker.Value;
			this.Close();
		}
	}
}
