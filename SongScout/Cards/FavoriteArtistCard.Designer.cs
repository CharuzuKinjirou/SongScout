
namespace SongScout.Cards
{
    partial class FavoriteArtistCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoriteArtistCard));
            this.FavCardArtistPictureBox = new Bunifu.UI.WinForms.BunifuPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FavCardArtistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // FavCardArtistPictureBox
            // 
            this.FavCardArtistPictureBox.AllowFocused = false;
            this.FavCardArtistPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FavCardArtistPictureBox.AutoSizeHeight = true;
            this.FavCardArtistPictureBox.BorderRadius = 17;
            this.FavCardArtistPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FavCardArtistPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("FavCardArtistPictureBox.Image")));
            this.FavCardArtistPictureBox.IsCircle = true;
            this.FavCardArtistPictureBox.Location = new System.Drawing.Point(0, 0);
            this.FavCardArtistPictureBox.Name = "FavCardArtistPictureBox";
            this.FavCardArtistPictureBox.Size = new System.Drawing.Size(35, 35);
            this.FavCardArtistPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.FavCardArtistPictureBox.TabIndex = 0;
            this.FavCardArtistPictureBox.TabStop = false;
            this.FavCardArtistPictureBox.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // FavoriteArtistCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.FavCardArtistPictureBox);
            this.Name = "FavoriteArtistCard";
            this.Size = new System.Drawing.Size(35, 35);
            ((System.ComponentModel.ISupportInitialize)(this.FavCardArtistPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox FavCardArtistPictureBox;
    }
}
