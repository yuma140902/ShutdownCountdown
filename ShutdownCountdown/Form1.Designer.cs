namespace ShutdownCountdown
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ShowWindowMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.timeRemainingLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.contextMenuNotifyIcon.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.BalloonTipText = "ShutdownContdown";
			this.notifyIcon.BalloonTipTitle = "ShutdownContdown";
			this.notifyIcon.ContextMenuStrip = this.contextMenuNotifyIcon;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "ShutdownContdown";
			this.notifyIcon.Visible = true;
			this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
			// 
			// contextMenuNotifyIcon
			// 
			this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowWindowMenu});
			this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
			this.contextMenuNotifyIcon.Size = new System.Drawing.Size(146, 26);
			// 
			// ShowWindowMenu
			// 
			this.ShowWindowMenu.Name = "ShowWindowMenu";
			this.ShowWindowMenu.Size = new System.Drawing.Size(145, 22);
			this.ShowWindowMenu.Text = "画面を表示(&S)";
			this.ShowWindowMenu.Click += new System.EventHandler(this.ShowWindowMenu_Click);
			// 
			// timer
			// 
			this.timer.Interval = 1000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// timeRemainingLabel
			// 
			this.timeRemainingLabel.AutoSize = true;
			this.timeRemainingLabel.Font = new System.Drawing.Font("Noto Mono", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.timeRemainingLabel.Location = new System.Drawing.Point(12, 21);
			this.timeRemainingLabel.Name = "timeRemainingLabel";
			this.timeRemainingLabel.Size = new System.Drawing.Size(458, 120);
			this.timeRemainingLabel.TabIndex = 1;
			this.timeRemainingLabel.Text = "00:00:00";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(262, 159);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(206, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "保存されていない変更は消えてしまいます。";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "シャットダウンまで残り";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(480, 180);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.timeRemainingLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "シャットダウンまでの残り時間 - ShutdownCountdown";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.contextMenuNotifyIcon.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
		private System.Windows.Forms.ToolStripMenuItem ShowWindowMenu;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Label timeRemainingLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

