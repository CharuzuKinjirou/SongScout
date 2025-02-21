
namespace SongScout
{
    partial class SplashForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadingProgressBar = new Bunifu.UI.WinForms.BunifuProgressBar();
            this.LoadingPackageLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.SplashScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.VersionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(209, 160);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 238);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadingProgressBar
            // 
            this.LoadingProgressBar.AllowAnimations = false;
            this.LoadingProgressBar.Animation = 0;
            this.LoadingProgressBar.AnimationSpeed = 50;
            this.LoadingProgressBar.AnimationStep = 10;
            this.LoadingProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.LoadingProgressBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LoadingProgressBar.BackgroundImage")));
            this.LoadingProgressBar.BorderColor = System.Drawing.Color.Transparent;
            this.LoadingProgressBar.BorderRadius = 1;
            this.LoadingProgressBar.BorderThickness = 1;
            this.LoadingProgressBar.Location = new System.Drawing.Point(-7, 562);
            this.LoadingProgressBar.Maximum = 104;
            this.LoadingProgressBar.MaximumValue = 104;
            this.LoadingProgressBar.Minimum = 0;
            this.LoadingProgressBar.MinimumValue = 0;
            this.LoadingProgressBar.Name = "LoadingProgressBar";
            this.LoadingProgressBar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LoadingProgressBar.ProgressBackColor = System.Drawing.Color.Transparent;
            this.LoadingProgressBar.ProgressColorLeft = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.LoadingProgressBar.ProgressColorRight = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.LoadingProgressBar.Size = new System.Drawing.Size(977, 13);
            this.LoadingProgressBar.TabIndex = 1;
            this.LoadingProgressBar.Value = 0;
            this.LoadingProgressBar.ValueByTransition = 0;
            this.LoadingProgressBar.ProgressChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs>(this.LoadingProgressBar_ProgressChanged);
            // 
            // LoadingPackageLabel
            // 
            this.LoadingPackageLabel.AllowParentOverrides = false;
            this.LoadingPackageLabel.AutoEllipsis = false;
            this.LoadingPackageLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.LoadingPackageLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.LoadingPackageLabel.Font = new System.Drawing.Font("Century Gothic", 6.75F);
            this.LoadingPackageLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoadingPackageLabel.Location = new System.Drawing.Point(6, 546);
            this.LoadingPackageLabel.Name = "LoadingPackageLabel";
            this.LoadingPackageLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoadingPackageLabel.Size = new System.Drawing.Size(71, 13);
            this.LoadingPackageLabel.TabIndex = 2;
            this.LoadingPackageLabel.Text = "Loading Setup...";
            this.LoadingPackageLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoadingPackageLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // SplashScreenTimer
            // 
            this.SplashScreenTimer.Tick += new System.EventHandler(this.SplashScreenTimer_Tick);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.VersionLabel.Location = new System.Drawing.Point(598, 281);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(32, 16);
            this.VersionLabel.TabIndex = 3;
            this.VersionLabel.Text = "v0.9";
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(852, 569);
            this.ControlBox = false;
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.LoadingPackageLabel);
            this.Controls.Add(this.LoadingProgressBar);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuProgressBar LoadingProgressBar;
        private Bunifu.UI.WinForms.BunifuLabel LoadingPackageLabel;
        private System.Windows.Forms.Timer SplashScreenTimer;
        private System.Windows.Forms.Label VersionLabel;
    }
}