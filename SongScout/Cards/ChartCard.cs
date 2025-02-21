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
    public partial class ChartCard : UserControl
    {
        public ChartCard()
        {
            InitializeComponent();
        }

        private string imageLocation;

        public string PlaylistImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; ChartCardPictureBox.ImageLocation = value; }
        }

    }
}
