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
    public partial class SplashForm : Form
    {
        MainForm mainForm = new MainForm();

        public SplashForm()
        {
            InitializeComponent();
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            this.SplashScreenTimer.Start();
        }

        private void SplashScreenTimer_Tick(object sender, EventArgs e)
        {
            this.LoadingProgressBar.Value += 2;
            if (this.LoadingProgressBar.Value == 100)
            {
                this.Hide();
            }

            if (this.LoadingProgressBar.Value == 104)
            {
                this.SplashScreenTimer.Stop();
                mainForm.Show();
            }
        }

        private void LoadingProgressBar_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs e)
        {
            if (this.LoadingProgressBar.Value == 20)
            {
                this.LoadingPackageLabel.Text = "Loading Helpers...";
            }
            else if (this.LoadingProgressBar.Value == 30)
            {
                this.LoadingPackageLabel.Text = "Loading Librespot Models...";
            }
            else if (this.LoadingProgressBar.Value == 40)
            {
                this.LoadingPackageLabel.Text = "Connecting Spotify API...";
            }
            else if (this.LoadingProgressBar.Value == 50)
            {
                this.LoadingPackageLabel.Text = "Connecting Third-Party API...";
            }
            else if (this.LoadingProgressBar.Value == 80)
            {
                this.LoadingPackageLabel.Text = "Loading Bunifu UI Package...";
            }
            else if (this.LoadingProgressBar.Value == 90)
            {
                this.LoadingPackageLabel.Text = "Initializing Forms...";
            } 
        }
    }
}
