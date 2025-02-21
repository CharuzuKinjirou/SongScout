
namespace SongScout
{
    partial class ChartCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartCard));
            this.ChartCardPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ChartCardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartCardPictureBox
            // 
            this.ChartCardPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ChartCardPictureBox.BackgroundImage")));
            this.ChartCardPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ChartCardPictureBox.Location = new System.Drawing.Point(0, 0);
            this.ChartCardPictureBox.Name = "ChartCardPictureBox";
            this.ChartCardPictureBox.Size = new System.Drawing.Size(143, 143);
            this.ChartCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ChartCardPictureBox.TabIndex = 0;
            this.ChartCardPictureBox.TabStop = false;
            // 
            // ChartCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ChartCardPictureBox);
            this.Name = "ChartCard";
            this.Size = new System.Drawing.Size(143, 143);
            ((System.ComponentModel.ISupportInitialize)(this.ChartCardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ChartCardPictureBox;
    }
}
