using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SongScout.Misc.NumberFormatter;

namespace SongScout
{
    public partial class ReleaseCard : UserControl
    {
        public ReleaseCard()
        {
            InitializeComponent();
        }

        public void AddTrackCard(UserControl trackCard)
        {
            ReleaseCardPanel.Controls.Add(trackCard);
        }

        private string albumImageUrl;
        private string albumName;
        private double albumStreams;
        private double albumSales;
        private DateTime albumDate;
        private string albumLabel;
        private string albumUpc;
        private string albumId;
        private Size releaseCardSize;

        public string AlbumImageUrl
        {
            get { return albumImageUrl; }
            set { albumImageUrl = value; ReleaseCardAlbumCoverPictureBox.ImageLocation = value; }
        }

        public string AlbumName
        { 
            get { return albumName; }
            set { albumName = value; ReleaseCardAlbumTitleLabel.Text = value; }
        }

        public double AlbumStreams
        {
            get { return albumStreams; }
            set { albumStreams = value; ReleaseCardAlbumStreamsLabel.Text = value.ToString("#,###"); }
        }

        public double AlbumSales
        {
            get { return albumSales; }
            set { albumSales = value; ReleaseCardAlbumSalesLabel.Text = numberFormat(value).ToString(); }
        }

        public DateTime AlbumDate
        {
            get { return albumDate; }
            set { albumDate = value; ReleaseCardAlbumDateLabel.Text = value.ToString("MMMM dd, yyyy"); }
        }

        public string AlbumLabel
        {
            get { return albumLabel; }
            set { albumLabel = value; ReleaseCardLabelLabel.Text = value; }
        }

        public string AlbumUpc
        {
            get { return albumUpc; }
            set { albumUpc = value; ReleaseCardAlbumUPCLabel.Text = value; }
        }

        public string AlbumId
        {
            get { return albumId; }
            set { albumId = value; ReleaseCardAlbumIdLabel.Text = value; }
        }

        public Size ReleaseCardSize
        {
            get { return releaseCardSize; }
            set { releaseCardSize = value; ReleaseCardPanel.Size = value; }
        }
    }
}
