using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongScout.Cards
{
    public partial class FavoriteArtistCard : UserControl
    {
        public FavoriteArtistCard()
        {
            InitializeComponent();
            WireAllControls(this);
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

        private string artistID;
        private string artistImageUrl;

        public string ArtistId
        {
            get { return artistID; }
            set { artistID = value; }
        }

        public string ArtistImageUrl
        {
            get { return artistImageUrl; }
            set { artistImageUrl = value; FavCardArtistPictureBox.ImageLocation = value; }
        }
    }
}
