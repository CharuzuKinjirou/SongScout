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
    public partial class TrackCard : UserControl
    {
        public TrackCard()
        {
            InitializeComponent();
            WireAllControls(this);
            TrackCardTitleLabel.MouseHover += Track_MouseHover;
            TrackCardTitleLabel.MouseLeave += Track_MouseLeave;
        }

        private int trackNumber;
        private string trackName;
        private double trackStreams;
        private double trackSales;
        private string trackId;

        public int TrackNumber
        {
            get { return trackNumber; }
            set { trackNumber = value; TrackCardNumberLabel.Text = value.ToString(); }
        }

        public string TrackName
        {
            get { return trackName; }
            set { trackName = value; TrackCardTitleLabel.Text = value; }
        }

        public double TrackStreams
        {
            get { return trackStreams; }
            set { trackStreams = value; TrackCardStreamsLabel.Text = value.ToString("#,###"); }
        }

        public double TrackSales
        {
            get { return trackSales; }
            set { trackSales = value; TrackCardSalesLabel.Text = numberFormat(value).ToString(); }
        }

        public string TrackId
        {
            get { return trackId; }
            set { trackId = value; }
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

        private void Track_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            TrackCardPanel.BackColor = Color.FromArgb(32, 32, 32);
        }
        private void Track_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            TrackCardPanel.BackColor = Color.FromArgb(27, 27, 27);
        }
    }
}
