using ShutdownCountdown.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutdownCountdown
{
	public static class Program
	{

		public static ModelTime Model;

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var settingForm = new SettingForm();
			settingForm.ShowDialog();
			if(settingForm.DialogResult != DialogResult.OK) {
				return;
			}

			Application.Run(new Form1(Model));
		}
	}
}
