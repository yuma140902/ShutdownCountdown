using ShutdownCountdown.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutdownCountdown
{
	public partial class Form1 : Form
	{
		private readonly ModelTime Model;

		public Form1(ModelTime model)
		{
			InitializeComponent();
			this.Model = model;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timer.Enabled = true;
		}


		#region 表示・非表示に関わる部分
		// ================= 表示・非表示に関わる部分 ここから =================

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.Model.IsInWarningPhase()) {
				this.Visible = false;
			}

			if (e.CloseReason != CloseReason.WindowsShutDown) {
				e.Cancel = true;
			}
		}

		private void ShowWindowMenu_Click(object sender, EventArgs e) => this.Visible = true;

		private void notifyIcon_Click(object sender, EventArgs e) => this.Visible = true;

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			// 最小化されたらキャンセル
			if (this.WindowState == FormWindowState.Minimized) {
				this.WindowState = FormWindowState.Normal;

				// 残り時間が5分以上のときのみ非表示にする
				if (!this.Model.IsInWarningPhase()) {
					this.Visible = false;
				}
			}

		}

		// ================= 表示・非表示に関わる部分 ここまで =================
		#endregion


		private void StartWarningPhase()
		{
			void DecorateUI()
			{
				this.BackColor = Color.Red;
				timeRemainingLabel.BackColor = Color.Red;
				contextMenuNotifyIcon.BackColor = Color.Red;
			}

			DecorateUI();
			this.TopMost = true;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			if (this.Visible) {
				timeRemainingLabel.Text = this.Model.TimeRemaining().ToString(@"hh\:mm\:ss");
				if (this.Model.IsInWarningPhase()) {
					StartWarningPhase();
				}
			}
			else {
				if (this.Model.IsInWarningPhase()) {
					this.Visible = true;
				}
			}

			if (this.Model.IsInShutdownPhase()) {
				Win32Shutdown.Shutdown();
			}
		}


		private void shutdownNowBtn_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show(
				"本当にシャットダウンして良いですか。\n保存されていないデータは失われます。", 
				"確認", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if(result == DialogResult.Yes) {
				Win32Shutdown.Shutdown();
			}

		}

	}
}
