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
		public Form1()
		{
			InitializeComponent();
		}

		private int SecondsRemaining;
		private bool IsInWarningPhase = false;

		private void Form1_Load(object sender, EventArgs e)
		{
			this.SecondsRemaining = (int)(Program.TimeToShutdown - DateTime.Now).TotalSeconds;
			timer.Enabled = true;
		}


		#region 表示・非表示に関わる部分
		// ================= 表示・非表示に関わる部分 ここから =================

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.IsInWarningPhase) {
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
				if (!this.IsInWarningPhase) {
					this.Visible = false;
				}
			}

		}

		// ================= 表示・非表示に関わる部分 ここまで =================
		#endregion


		private void StartWarningPhase()
		{
			if (this.IsInWarningPhase) {
				return;
			}

			void DecorateUI()
			{
				this.BackColor = Color.Red;
				timeRemainingLabel.BackColor = Color.Red;
				contextMenuNotifyIcon.BackColor = Color.Red;
			}

			this.IsInWarningPhase = true;
			DecorateUI();
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			--SecondsRemaining;
			if (this.Visible) {
				var timeLeft = TimeSpan.FromSeconds(SecondsRemaining);
				timeRemainingLabel.Text = timeLeft.ToString(@"hh\:mm\:ss");
				if (timeLeft.TotalMinutes <= 5) {
					StartWarningPhase();
					this.TopMost = true;
				}
			}
			else {
				if (SecondsRemaining <= 60 * 5) {
					this.Visible = true;
				}
			}

			if (SecondsRemaining <= 0) {
				Win32Shutdown.Shutdown();
			}
		}


		private void shutdownNowBtn_Click(object sender, EventArgs e)
		{
			var result = MessageBox.Show(
				"本当にシャットダウンして良いですか。\n保存されていないデータは失われます。", 
				"確認", 
				MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if(result != DialogResult.Yes) {
				return;
			}

			Win32Shutdown.Shutdown();
		}
	}
}
