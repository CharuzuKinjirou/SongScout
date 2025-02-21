using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongScout
{
    public partial class ResultCard : UserControl
    {
        public ResultCard()
        {
            InitializeComponent();
            WireAllControls(this);
            SearchResultCard.MouseHover += Card_MouseHover;
            SearchResultCard.MouseLeave += Card_MouseLeave;
            ResultArtistNameLabel.MouseHover += Card_MouseHover;
            ResultArtistNameLabel.MouseLeave += Card_MouseLeave;
            ResultImagePictureBox.MouseHover += Card_MouseHover;
            ResultImagePictureBox.MouseLeave += Card_MouseLeave;
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += Ctr_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void Ctr_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }

        private string imageUrl;
        private string spotifyId;
        private string name;

        public string ArtistImageUrl
        {
            get { return imageUrl; }
            set { imageUrl = value; ResultImagePictureBox.ImageLocation = value;  }
        }

        public string ArtistName
        {
            get { return name; }
            set { name = value; ResultArtistNameLabel.Text = value; }
        }

        public string ArtistId
        {
            get { return spotifyId; }
            set { spotifyId = value; }
        }

        private void Card_MouseLeave(object sender, EventArgs e)
        {
            SearchResultCard.BackColor = Color.FromArgb(23, 23, 23);
        }
        private void Card_MouseHover(object sender, EventArgs e)
        {
            SearchResultCard.BackColor = Color.FromArgb(35, 35, 35);
        }
    }
}