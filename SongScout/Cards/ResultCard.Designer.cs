
namespace SongScout
{
    partial class ResultCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultCard));
            this.SearchResultCard = new Bunifu.Framework.UI.BunifuCards();
            this.ResultArtistNameLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.ResultImagePictureBox = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.SearchResultCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchResultCard
            // 
            this.SearchResultCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.SearchResultCard.BorderRadius = 20;
            this.SearchResultCard.BottomSahddow = false;
            this.SearchResultCard.color = System.Drawing.Color.Transparent;
            this.SearchResultCard.Controls.Add(this.ResultArtistNameLabel);
            this.SearchResultCard.Controls.Add(this.ResultImagePictureBox);
            this.SearchResultCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SearchResultCard.LeftSahddow = false;
            this.SearchResultCard.Location = new System.Drawing.Point(0, 0);
            this.SearchResultCard.Name = "SearchResultCard";
            this.SearchResultCard.RightSahddow = false;
            this.SearchResultCard.ShadowDepth = 20;
            this.SearchResultCard.Size = new System.Drawing.Size(128, 174);
            this.SearchResultCard.TabIndex = 0;
            // 
            // ResultArtistNameLabel
            // 
            this.ResultArtistNameLabel.AllowParentOverrides = false;
            this.ResultArtistNameLabel.AutoEllipsis = true;
            this.ResultArtistNameLabel.AutoSize = false;
            this.ResultArtistNameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResultArtistNameLabel.CursorType = System.Windows.Forms.Cursors.Hand;
            this.ResultArtistNameLabel.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Bold);
            this.ResultArtistNameLabel.ForeColor = System.Drawing.Color.Transparent;
            this.ResultArtistNameLabel.Location = new System.Drawing.Point(12, 133);
            this.ResultArtistNameLabel.Name = "ResultArtistNameLabel";
            this.ResultArtistNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResultArtistNameLabel.Size = new System.Drawing.Size(105, 17);
            this.ResultArtistNameLabel.TabIndex = 2;
            this.ResultArtistNameLabel.Text = "Artist Name";
            this.ResultArtistNameLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ResultArtistNameLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ResultImagePictureBox
            // 
            this.ResultImagePictureBox.AllowFocused = false;
            this.ResultImagePictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ResultImagePictureBox.AutoSizeHeight = true;
            this.ResultImagePictureBox.BorderRadius = 50;
            this.ResultImagePictureBox.Image = ((System.Drawing.Image)(resources.GetObject("ResultImagePictureBox.Image")));
            this.ResultImagePictureBox.IsCircle = true;
            this.ResultImagePictureBox.Location = new System.Drawing.Point(14, 16);
            this.ResultImagePictureBox.Name = "ResultImagePictureBox";
            this.ResultImagePictureBox.Size = new System.Drawing.Size(100, 100);
            this.ResultImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ResultImagePictureBox.TabIndex = 1;
            this.ResultImagePictureBox.TabStop = false;
            this.ResultImagePictureBox.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // ResultCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.SearchResultCard);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ResultCard";
            this.Size = new System.Drawing.Size(128, 174);
            this.SearchResultCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCards SearchResultCard;
        private Bunifu.UI.WinForms.BunifuPictureBox ResultImagePictureBox;
        private Bunifu.UI.WinForms.BunifuLabel ResultArtistNameLabel;
    }
}
