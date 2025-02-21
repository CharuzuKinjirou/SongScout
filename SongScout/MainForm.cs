using Newtonsoft.Json;
using SongScout.Helpers;
using SongScout.LibrespotModels;
using SpotifyAPI.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SongScout.Helpers.LibrespotHelper;
using static SpotifyAPI.Web.SearchRequest;
using static SongScout.Misc.NumberFormatter;
using static SongScout.Helpers.ChartHelper;
using System.Runtime.InteropServices;
using Bunifu.Framework.UI;
using javax.naming.ldap;
using Bunifu.UI.WinForms;
using System.Media;
using NAudio.Wave;
using System.Threading;
using BunifuProgressBar = Bunifu.UI.WinForms.BunifuProgressBar;
using SongScout.Cards;

namespace SongScout
{
    public partial class MainForm : Form
    {
        public string token;
        public List<FullArtist> artistResults;
        public List<string> favorites = new List<string>();
        public string selectedArtistId;
        public string selectedArtistName;
        public bool isDataAvailable = false;
        public bool isSinglesOpened = false;
        public bool isAlbumsOpened = false;
        public bool isCompilationsOpened = false;
        public bool isChartsOpened = false;
        public string trackPreviewUrl;
        public string trackSpotifyUrl;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
        );

        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            SpotifyHelper search = new SpotifyHelper();
            await search.GetToken();
            token = search.OauthToken;
            OverviewButton.Enabled = false;
            SinglesButton.Enabled = false;
            AlbumsButton.Enabled = false;
            CompilationsButton.Enabled = false;
            ChartsButton.Enabled = false;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.MainPages.PageIndex = 0;
            LoadingCoverPanel.Visible = false;
        }

        private void OverviewButton_Click(object sender, EventArgs e)
        {
            if (!isDataAvailable) LoadingCoverPanel.Visible = true;
            if (isDataAvailable) LoadingCoverPanel.Visible = false;
            this.MainPages.PageIndex = 1;
        }

        private void SinglesButton_Click(object sender, EventArgs e)
        {
            if (!isSinglesOpened)
            {
                Cursor = Cursors.WaitCursor;
                LoadingCoverPanel.Visible = true;
                var values = GetSinglesData(token, selectedArtistId, SinglesPanel);

                // Populate the data on the labels
                SP_TotalSinglesLabel.Text = values[0].ToString();
                SP_TotalStreamsLabel.Text = values[1] == 0 ? "—" : values[1].ToString("#,###");
                SP_TotalSalesLabel.Text = values[2] == 0 ? "—" : numberFormat(values[2]).ToString();

                if (values[0] == 0) SinglesEmptyPanel.Visible = true;
                this.MainPages.PageIndex = 2;
                isSinglesOpened = true;
                LoadingCoverPanel.Visible = false;
                Cursor = Cursors.Default;
            }

            this.MainPages.PageIndex = 2;
        }

        private void AlbumsButton_Click(object sender, EventArgs e)
        {
            if (!isAlbumsOpened)
            {
                Cursor = Cursors.WaitCursor;
                LoadingCoverPanel.Visible = true;
                var values = GetAlbumsData(token, selectedArtistId, AlbumsPanel);

                // Populate the data on the labels
                AP_TotalAlbumsLabel.Text = values[0].ToString();
                AP_TotalStreamsLabel.Text = values[1] == 0 ? "—" : values[1].ToString("#,###");
                AP_TotalSalesLabel.Text = values[2] == 0 ? "—" : numberFormat(values[2]).ToString();

                if (values[0] == 0) AlbumsEmptyPanel.Visible = true;
                this.MainPages.PageIndex = 3;
                isAlbumsOpened = true;
                LoadingCoverPanel.Visible = false;
                Cursor = Cursors.Default;
            }

            this.MainPages.PageIndex = 3;
        }

        private void CompilationsButton_Click(object sender, EventArgs e)
        {
            if (!isCompilationsOpened)
            {
                Cursor = Cursors.WaitCursor;
                LoadingCoverPanel.Visible = true;
                var values = GetCompilationsData(token, selectedArtistId, CompilationsPanel);

                // Populate the data on the labels
                CP_TotalCompilationsLabel.Text = values[0].ToString();
                CP_TotalStreamsLabel.Text = values[1] == 0 ? "—" : values[1].ToString("#,###");
                CP_TotalSalesLabel.Text = values[2] == 0 ? "—" : numberFormat(values[2]).ToString();

                if (values[0] == 0) CompEmptyPanel.Visible = true;
                this.MainPages.PageIndex = 4;
                isCompilationsOpened = true;
                LoadingCoverPanel.Visible = false;
                Cursor = Cursors.Default;
            }

            this.MainPages.PageIndex = 4;
        }

        private void ChartsButton_Click(object sender, EventArgs e)
        {
            if (!isChartsOpened)
            {
                Cursor = Cursors.WaitCursor;
                LoadingCoverPanel.Visible = true;
                var spotify = new SpotifyClient(token);
                ChartHelper chartHelper = new ChartHelper();
                List<string> dailyTopChartEntries = chartHelper.GetDailyTopCharts(selectedArtistId, token);
                List<string> dailyViralChartEntries = chartHelper.GetDailyViralCharts(selectedArtistId, token);
                List<string> weeklyTopChartEntries = chartHelper.GetWeeklyTopCharts(selectedArtistId, token);
                //   List<string> weeklyViralChartEntries = chartHelper.GetWeeklyViralCharts(selectedArtistId, token);
                var totalPlayListReach = 0;
                

                for (int i = 0; i < dailyTopChartEntries.Count; i++)
                {
                    totalPlayListReach += spotify.Playlists.Get(dailyTopChartEntries[i]).Result.Followers.Total;
                    ChartCard a = new ChartCard();
                    a.PlaylistImageLocation = spotify.Playlists.GetCovers(dailyTopChartEntries[i]).Result[0].Url;
                    DailyTopFlowPanel.Controls.Add(a);
                }

                for (int i = 0; i < dailyViralChartEntries.Count; i++)
                {
                    totalPlayListReach += spotify.Playlists.Get(dailyViralChartEntries[i]).Result.Followers.Total;
                    ChartCard b = new ChartCard();
                    b.PlaylistImageLocation = spotify.Playlists.GetCovers(dailyViralChartEntries[i]).Result[0].Url;
                    DailyViralFlowPanel.Controls.Add(b);
                }

                for (int i = 0; i < weeklyTopChartEntries.Count; i++)
                {
                    totalPlayListReach += spotify.Playlists.Get(weeklyTopChartEntries[i]).Result.Followers.Total;
                    ChartCard c = new ChartCard();
                    c.PlaylistImageLocation = spotify.Playlists.GetCovers(weeklyTopChartEntries[i]).Result[0].Url;
                    WeeklyTopFlowPanel.Controls.Add(c);
                }
                /*
                for (int i = 0; i < weeklyViralChartEntries.Count; i++)
                {
                    ChartCard d = new ChartCard();
                    d.PlaylistImageLocation = spotify.Playlists.GetCovers(weeklyViralChartEntries[i]).Result[0].Url;
                    WeeklyViralFlowPanel.Controls.Add(d);
                }
                */
                TotalChartEntriesLabel.Text = Convert.ToString(dailyTopChartEntries.Count + 
                                                               dailyViralChartEntries.Count + 
                                                               weeklyTopChartEntries.Count);
                TotalPlaylistFollowersLabel.Text = totalPlayListReach.ToString("##,###");

                if (dailyTopChartEntries.Count + dailyViralChartEntries.Count + weeklyTopChartEntries.Count == 0)
                    ChartsEmptyPanel.Visible = true;

                this.MainPages.PageIndex = 5;
                isChartsOpened = true;
                LoadingCoverPanel.Visible = false;
                Cursor = Cursors.Default;
            }

            this.MainPages.PageIndex = 5;
        }

        private async void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor = Cursors.WaitCursor;
                SearchCoverPanel.Visible = true;
                OverviewButton.Enabled = true;
                SinglesButton.Enabled = true;
                AlbumsButton.Enabled = true;
                CompilationsButton.Enabled = true;
                ChartsButton.Enabled = true;

                // Request Spotify API and Librespot API
                var searchString = SearchTextBox.Text;
                var spotifyClient = new SpotifyClient(token);
                var artistSearch = await spotifyClient.Search.Item(new SearchRequest(Types.Artist, searchString));
                LibrespotHelper librespotHelper = new LibrespotHelper();
                artistResults = artistSearch.Artists.Items;

                // Display card results
                var cardLocX = 1;
                var cardLocY = 1;

                for (int i = 0; i < artistResults.Count; i++)
                {
                    // Request information on each artist result
                    var artistInfo = librespotHelper.GetArtistInsights(artistResults[i].Id);

                    // Add a result card on each artist result
                    ResultCard ArtistResultCard = new ResultCard
                    {
                        ArtistImageUrl = artistInfo.Data.MainImageUrl,
                        ArtistName = artistInfo.Data.Name,
                        ArtistId = artistResults[i].Id,
                        Location = new Point(cardLocX, cardLocY)
                    };
                    ResultsPanel.Controls.Add(ArtistResultCard);
                    ArtistResultCard.Click += CardClick;

                    if (i >= 5 && i % 5 == 0)
                    {
                        cardLocY += 197;
                        cardLocX = 1;
                    }
                    else { cardLocX += 147; }
                }

                SearchPageScrollBar.Visible = true;
                SearchCoverPanel.Visible = false;
                Cursor = Cursors.Default;
            }
        }

        public void CardClick(object sender, EventArgs e)
        {
            // Construct labels of each tracks
            List<BunifuLabel> mostStreamedName = new List<BunifuLabel>
            {
                MostStreamed1NameLabel,
                MostStreamed2NameLabel,
                MostStreamed3NameLabel,
                MostStreamed4NameLabel,
                MostStreamed5NameLabel
            };
            List<BunifuLabel> mostStreamedPlaycount = new List<BunifuLabel>
            {
                MostStreamed1CountLabel,
                MostStreamed2CountLabel,
                MostStreamed3CountLabel,
                MostStreamed4CountLabel,
                MostStreamed5CountLabel
            };
            // Clear texts on the track labels
            for (int j = 0; j < 5; j++) { mostStreamedName[j].Text = ""; mostStreamedPlaycount[j].Text = ""; }

            ResultCard card = sender as ResultCard;
            selectedArtistId = card.ArtistId;
            LoadingCoverPanel.Visible = true;
            OverviewButton.Focus();
            Cursor = Cursors.WaitCursor;
            SinglesEmptyPanel.Visible = false;
            AlbumsEmptyPanel.Visible = false;
            CompEmptyPanel.Visible = false;
            ChartsEmptyPanel.Visible = false;
            SP_TrackCover.Visible = true;
            AP_TrackCover.Visible = true;
            CP_TrackCover.Visible = true;
            SearchCoverPanel.Visible = false;
            OverviewButton.Visible = true;
            SinglesButton.Visible = true;
            AlbumsButton.Visible = true;
            CompilationsButton.Visible = true;
            ChartsButton.Visible = true;

            LibrespotHelper librespot = new LibrespotHelper();
            var artistInsights = librespot.GetArtistInsights(selectedArtistId);
            var selectedArtistInfo = librespot.GetArtistInfo(selectedArtistId);
            var spotify = new SpotifyClient(token);
            var artist = spotify.Artists.Get(selectedArtistId);

            selectedArtistName = artist.Result.Name;
            var monthlyListeners = artistInsights.Data.MonthlyListeners;
            var followers = artist.Result.Followers.Total;
            var popularityScore = artist.Result.Popularity;
            var globalPosition = artistInsights.Data.GlobalChartPosition;
            var totalStreams = librespot.GetAllTimeStreams(selectedArtistId, token);

            var totalSingles = 0;
            var totalAlbums = 0;
            var totalCompilations = 0;

            if (selectedArtistInfo.Data.Releases.Singles.Releases != null)
                totalSingles = selectedArtistInfo.Data.Releases.Singles.Releases.Count;

            if (selectedArtistInfo.Data.Releases.Albums.Releases != null)
                totalAlbums = selectedArtistInfo.Data.Releases.Albums.Releases.Count;

            if (selectedArtistInfo.Data.Releases.Compilations.Releases != null)
                totalCompilations = selectedArtistInfo.Data.Releases.Compilations.Releases.Count;

            if (globalPosition == 0) { GlobalRankLabel.Text = "—"; }
            else { GlobalRankLabel.Text = globalPosition.ToString(); }

            librespot.OrderTracks(librespot.totalTracks, token);
            for (int j = 0; j < librespot.mostStreamedTracksName.Count; j++)
            {
                mostStreamedName[j].Text = librespot.mostStreamedTracksName[j];
                mostStreamedPlaycount[j].Text = librespot.mostStreamedTracksPlaycount[j].ToString("#,###");
            }

            if (favorites.Contains(selectedArtistId)) FavoriteArtistToggleSwitch.Checked = true;
            if (!favorites.Contains(selectedArtistId)) FavoriteArtistToggleSwitch.Checked = false;
            // Write data on controls in overview page
            OverviewArtistPictureBox.ImageLocation = card.ArtistImageUrl;
            SelectedArtistIdTextbox.Text = selectedArtistId;
            OverviewArtistNameLabel.Text = selectedArtistName;
            TotalStreamsLabel.Text = totalStreams.ToString("#,###");
            TotalSalesLabel.Text = numberFormat(totalStreams * (310.0 / 207.0) / 1500.0).ToString();
            PopularityProgressBar.Value = popularityScore;
            MonthlyListenersLabel.Text = monthlyListeners.ToString("#,###");
            FollowersLabel.Text = followers.ToString("#,###");
            SinglesNumLabel.Text = totalSingles.ToString();
            AlbumsNumLabel.Text = totalAlbums.ToString();
            CompilationsNumLabel.Text = totalCompilations.ToString();
            TotalTracksLabel.Text = librespot.totalTracks.Count.ToString();
            Tracks1BLabel.Text = librespot.tracksWith1B.ToString();
            Tracks100MLabel.Text = librespot.tracksWith100M.ToString();
            Tracks10MLabel.Text = librespot.tracksWith10M.ToString();
            Tracks1MLabel.Text = librespot.tracksWith1M.ToString();

            MainPages.PageIndex = 1;
            Cursor = Cursors.Default;
            SinglesPanel.Controls.Clear();
            AlbumsPanel.Controls.Clear();
            CompilationsPanel.Controls.Clear();
            DailyTopFlowPanel.Controls.Clear();
            DailyViralFlowPanel.Controls.Clear();
            WeeklyTopFlowPanel.Controls.Clear();
            WeeklyViralFlowPanel.Controls.Clear();
            isDataAvailable = true;
            isSinglesOpened = false;
            isAlbumsOpened = false;
            isCompilationsOpened = false;
            isChartsOpened = false;
            LoadingCoverPanel.Visible = false;
            SearchPageScrollBar.VerticalScroll.Value = 20;
        }

        public void FavoriteCardClick(object sender, EventArgs e)
        {
            // Construct labels of each tracks
            List<BunifuLabel> mostStreamedName = new List<BunifuLabel>
            {
                MostStreamed1NameLabel,
                MostStreamed2NameLabel,
                MostStreamed3NameLabel,
                MostStreamed4NameLabel,
                MostStreamed5NameLabel
            };
            List<BunifuLabel> mostStreamedPlaycount = new List<BunifuLabel>
            {
                MostStreamed1CountLabel,
                MostStreamed2CountLabel,
                MostStreamed3CountLabel,
                MostStreamed4CountLabel,
                MostStreamed5CountLabel
            };
            // Clear texts on the track labels
            for (int j = 0; j < 5; j++) { mostStreamedName[j].Text = ""; mostStreamedPlaycount[j].Text = ""; }

            FavoriteArtistCard card = sender as FavoriteArtistCard;
            selectedArtistId = card.ArtistId;
            LoadingCoverPanel.Visible = true;
            OverviewButton.Focus();
            Cursor = Cursors.WaitCursor;
            SinglesEmptyPanel.Visible = false;
            AlbumsEmptyPanel.Visible = false;
            CompEmptyPanel.Visible = false;
            ChartsEmptyPanel.Visible = false;
            SP_TrackCover.Visible = true;
            AP_TrackCover.Visible = true;
            CP_TrackCover.Visible = true;
            SearchCoverPanel.Visible = false;
            OverviewButton.Visible = true;
            SinglesButton.Visible = true;
            AlbumsButton.Visible = true;
            CompilationsButton.Visible = true;
            ChartsButton.Visible = true;

            LibrespotHelper librespot = new LibrespotHelper();
            var artistInsights = librespot.GetArtistInsights(selectedArtistId);
            var selectedArtistInfo = librespot.GetArtistInfo(selectedArtistId);
            var spotify = new SpotifyClient(token);
            var artist = spotify.Artists.Get(selectedArtistId);

            selectedArtistName = artist.Result.Name;
            var monthlyListeners = artistInsights.Data.MonthlyListeners;
            var followers = artist.Result.Followers.Total;
            var popularityScore = artist.Result.Popularity;
            var globalPosition = artistInsights.Data.GlobalChartPosition;
            var totalStreams = librespot.GetAllTimeStreams(selectedArtistId, token);

            var totalSingles = 0;
            var totalAlbums = 0;
            var totalCompilations = 0;

            if (selectedArtistInfo.Data.Releases.Singles.Releases != null)
                totalSingles = selectedArtistInfo.Data.Releases.Singles.Releases.Count;

            if (selectedArtistInfo.Data.Releases.Albums.Releases != null)
                totalAlbums = selectedArtistInfo.Data.Releases.Albums.Releases.Count;

            if (selectedArtistInfo.Data.Releases.Compilations.Releases != null)
                totalCompilations = selectedArtistInfo.Data.Releases.Compilations.Releases.Count;

            if (globalPosition == 0) { GlobalRankLabel.Text = "—"; }
            else { GlobalRankLabel.Text = globalPosition.ToString(); }

            librespot.OrderTracks(librespot.totalTracks, token);
            for (int j = 0; j < librespot.mostStreamedTracksName.Count; j++)
            {
                mostStreamedName[j].Text = librespot.mostStreamedTracksName[j];
                mostStreamedPlaycount[j].Text = librespot.mostStreamedTracksPlaycount[j].ToString("#,###");
            }

            if (favorites.Contains(selectedArtistId)) FavoriteArtistToggleSwitch.Checked = true;
            if (!favorites.Contains(selectedArtistId)) FavoriteArtistToggleSwitch.Checked = false;
            // Write data on controls in overview page
            OverviewArtistPictureBox.ImageLocation = card.ArtistImageUrl;
            SelectedArtistIdTextbox.Text = selectedArtistId;
            OverviewArtistNameLabel.Text = selectedArtistName;
            TotalStreamsLabel.Text = totalStreams.ToString("#,###");
            TotalSalesLabel.Text = numberFormat(totalStreams * (310.0 / 207.0) / 1500.0).ToString();
            PopularityProgressBar.Value = popularityScore;
            MonthlyListenersLabel.Text = monthlyListeners.ToString("#,###");
            FollowersLabel.Text = followers.ToString("#,###");
            SinglesNumLabel.Text = totalSingles.ToString();
            AlbumsNumLabel.Text = totalAlbums.ToString();
            CompilationsNumLabel.Text = totalCompilations.ToString();
            TotalTracksLabel.Text = librespot.totalTracks.Count.ToString();
            Tracks1BLabel.Text = librespot.tracksWith1B.ToString();
            Tracks100MLabel.Text = librespot.tracksWith100M.ToString();
            Tracks10MLabel.Text = librespot.tracksWith10M.ToString();
            Tracks1MLabel.Text = librespot.tracksWith1M.ToString();

            MainPages.PageIndex = 1;
            Cursor = Cursors.Default;
            SinglesPanel.Controls.Clear();
            AlbumsPanel.Controls.Clear();
            CompilationsPanel.Controls.Clear();
            DailyTopFlowPanel.Controls.Clear();
            DailyViralFlowPanel.Controls.Clear();
            WeeklyTopFlowPanel.Controls.Clear();
            WeeklyViralFlowPanel.Controls.Clear();
            isDataAvailable = true;
            isSinglesOpened = false;
            isAlbumsOpened = false;
            isCompilationsOpened = false;
            isChartsOpened = false;
            LoadingCoverPanel.Visible = false;
            SearchPageScrollBar.VerticalScroll.Value = 20;
        }

        public void Track_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            TrackCard card = sender as TrackCard;
            var spotify = new SpotifyClient(token);
            var trackName = spotify.Tracks.Get(card.TrackId).Result.Name;
            trackPreviewUrl = spotify.Tracks.Get(card.TrackId).Result.PreviewUrl;
            trackSpotifyUrl = spotify.Tracks.Get(card.TrackId).Result.ExternalUrls["spotify"];
            var trackISRC = spotify.Tracks.Get(card.TrackId).Result.ExternalIds["isrc"];
            var trackFeatures = spotify.Tracks.GetAudioFeatures(card.TrackId).Result;

            string[] keyArr = {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
            var duration = TimeSpan.FromMilliseconds(trackFeatures.DurationMs);
            var bpm = trackFeatures.Tempo;
            var key = keyArr[trackFeatures.Key];
            var acoustic = trackFeatures.Acousticness * 100;
            var live = trackFeatures.Liveness * 100;
            var speech = trackFeatures.Speechiness * 100;
            var instrument = trackFeatures.Instrumentalness * 100;
            var valence = trackFeatures.Valence * 100;
            var energy = trackFeatures.Energy * 100;
            var loud = trackFeatures.Loudness;
            var dance = trackFeatures.Danceability * 100;

            if (MainPages.PageIndex == 2)
            {
                SP_TrackNameLabel.Text = trackName;
                SP_TrackDurationLabel.Text = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);
                SP_TrackISRCLabel.Text = trackISRC;
                SP_TrackIBPM.Text = bpm.ToString("0");
                SP_TrackKey.Text = key.ToString();
                SP_TrackAcoustic.Text = acoustic.ToString("0") + "%";
                SP_TrackDance.Text = dance.ToString("0") + "%";
                SP_TrackEnergy.Text = energy.ToString("0") + "%";
                SP_TrackInstrument.Text = instrument.ToString("0") + "%";
                SP_TrackLive.Text = live.ToString("0") + "%";
                SP_TrackLoud.Text = loud.ToString("0") + "%";
                SP_TrackSpeech.Text = speech.ToString("0") + "%";
                SP_TrackValence.Text = valence.ToString("0") + "%";
            }
            else if (MainPages.PageIndex == 3)
            {
                AP_TrackName.Text = trackName;
                AP_TrackDuration.Text = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);
                AP_TrackISRC.Text = trackISRC;
                AP_TrackBPM.Text = bpm.ToString("0");
                AP_TrackKey.Text = key.ToString();
                AP_TrackAcoustic.Text = acoustic.ToString("0") + "%";
                AP_TrackDance.Text = dance.ToString("0") + "%";
                AP_TrackEnergy.Text = energy.ToString("0") + "%";
                AP_TrackInstrument.Text = instrument.ToString("0") + "%";
                AP_TrackLive.Text = live.ToString("0") + "%";
                AP_TrackLoud.Text = loud.ToString("0") + "%";
                AP_TrackSpeech.Text = speech.ToString("0") + "%";
                AP_TrackValence.Text = valence.ToString("0") + "%";
            }
            else if (MainPages.PageIndex == 4)
            {
                CP_TrackName.Text = trackName;
                CP_TrackDuration.Text = string.Format("{0:D2}:{1:D2}", duration.Minutes, duration.Seconds);
                CP_TrackISRC.Text = trackISRC;
                CP_TrackBPM.Text = bpm.ToString("0");
                CP_TrackKey.Text = key.ToString();
                CP_TrackAcoustic.Text = acoustic.ToString("0") + "%";
                CP_TrackDance.Text = dance.ToString("0") + "%";
                CP_TrackEnergy.Text = energy.ToString("0") + "%";
                CP_TrackInstrument.Text = instrument.ToString("0") + "%";
                CP_TrackLive.Text = live.ToString("0") + "%";
                CP_TrackLoud.Text = loud.ToString("0") + "%";
                CP_TrackSpeech.Text = speech.ToString("0") + "%";
                CP_TrackValence.Text = valence.ToString("0") + "%";
            }

            if (MainPages.PageIndex == 2)
                SP_TrackCover.Visible = false;
            if (MainPages.PageIndex == 3)
                AP_TrackCover.Visible = false;
            if (MainPages.PageIndex == 4)
                CP_TrackCover.Visible = false;

            Cursor = Cursors.Default;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchCoverPanel.Visible = true;
            ResultsPanel.Controls.Clear();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitConfirmationForm exitForm = new ExitConfirmationForm();
            exitForm.Show();
        }

        private void SP_PreviewButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            PlayMp3FromUrl(trackPreviewUrl + ".mp3", SP_PreviewProgressBar);
            Cursor = Cursors.Default;
        }

        private void SP_LinkButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(trackSpotifyUrl);
        }

        public double[] GetSinglesData(string token, string selectedArtistId, BunifuPanel panel)
        {
            double[] values = new double[3];
            var spotify = new SpotifyClient(token);
            LibrespotHelper librespot = new LibrespotHelper();
            var artistInfo = librespot.GetArtistInfo(selectedArtistId);

            // Get summary of streams and sales
            double totalReleaseStreams = 0.0;
            var releaseCardY = 1;
            var singlesList = artistInfo.Data.Releases.Singles.Releases;
            if (singlesList != null)
            {
                for (int singleIndex = 0; singleIndex < singlesList.Count; singleIndex++)
                {
                    if (singlesList == null) { totalReleaseStreams = 0.0; break; }

                    var albumId = singlesList[singleIndex].Uri.Replace("spotify:album:", "");
                    var albumInfo = spotify.Albums.Get(albumId);
                    var albumInfo2 = librespot.GetAlbumInfo(albumId);
                    double releaseStreams = librespot.GetReleaseStreams(albumInfo2);
                    totalReleaseStreams += releaseStreams;
                    // Add release card in the panel
                    ReleaseCard releaseCard = new ReleaseCard
                    {
                        AlbumName = albumInfo.Result.Name,
                        AlbumDate = DateTime.ParseExact(albumInfo.Result.ReleaseDate, @"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        AlbumLabel = albumInfo.Result.Label,
                        AlbumUpc = albumInfo.Result.ExternalIds["upc"],
                        AlbumId = albumInfo.Result.Id,
                        AlbumImageUrl = singlesList[singleIndex].Cover.Uri,
                        AlbumStreams = releaseStreams,
                        AlbumSales = releaseStreams * (310.0 / 207.0) / 1500.0,
                        Size = new Size(528, 235 + (25 * ((albumInfo.Result.Tracks.Total.Value)))),
                        ReleaseCardSize = new Size(528, 235 + (25 * ((albumInfo.Result.Tracks.Total.Value)))),
                        Location = new Point(2, releaseCardY)
                    };
                    panel.Controls.Add(releaseCard);

                    var trackCardY = 193;
                    var trackNum = 1;
                    var discList = albumInfo2.Data.Discs;
                    for (int discIndex = 0; discIndex < discList.Count; discIndex++)
                    {
                        var trackList = discList[discIndex].Tracks;
                        for (int trackIndex = 0; trackIndex < trackList.Count; trackIndex++)
                        {
                            var trackId = trackList[trackIndex].Uri.Replace("spotify:track:", "");
                            double trackStreams = librespot.GetTrackStreams(discIndex, trackIndex, albumInfo2);
                            // Add track card in the release card
                            TrackCard trackCard = new TrackCard
                            {
                                TrackName = trackList[trackIndex].Name,
                                TrackNumber = trackNum++,
                                TrackStreams = trackStreams,
                                TrackSales = trackStreams * (310.0 / 207.0) / 1500.0,
                                TrackId = trackId,
                                Location = new Point(2, trackCardY += 25)
                            };
                            trackCard.Click += Track_Click;
                            releaseCard.AddTrackCard(trackCard);
                        }
                    }

                    releaseCardY += (260 + (25 * ((albumInfo.Result.Tracks.Total.Value))));
                }
            }

            values[0] = singlesList == null ? 0 : singlesList.Count;
            values[1] = totalReleaseStreams;
            values[2] = totalReleaseStreams * (310.0 / 207.0) / 1500.0;

            return values;
        }

        public double[] GetAlbumsData(string token, string selectedArtistId, BunifuPanel panel)
        {
            double[] values = new double[3];
            var spotify = new SpotifyClient(token);
            LibrespotHelper librespot = new LibrespotHelper();
            var artistInfo = librespot.GetArtistInfo(selectedArtistId);

            // Get summary of streams and sales
            double totalReleaseStreams = 0.0;
            var releaseCardY = 1;
            var albumsList = artistInfo.Data.Releases.Albums.Releases;
            if (albumsList != null)
            {
                for (int albumIndex = 0; albumIndex < albumsList.Count; albumIndex++)
                {
                    if (albumsList == null) { totalReleaseStreams = 0.0; break; }

                    var albumId = albumsList[albumIndex].Uri.Replace("spotify:album:", "");
                    var albumInfo = spotify.Albums.Get(albumId);
                    var albumInfo2 = librespot.GetAlbumInfo(albumId);
                    double releaseStreams = librespot.GetReleaseStreams(albumInfo2);
                    totalReleaseStreams += releaseStreams;
                    // Add release card in the panel
                    ReleaseCard releaseCard = new ReleaseCard
                    {
                        AlbumName = albumInfo.Result.Name,
                        AlbumDate = DateTime.ParseExact(albumInfo.Result.ReleaseDate, @"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        AlbumLabel = albumInfo.Result.Label,
                        AlbumUpc = albumInfo.Result.ExternalIds["upc"],
                        AlbumId = albumInfo.Result.Id,
                        AlbumImageUrl = albumsList[albumIndex].Cover.Uri,
                        AlbumStreams = releaseStreams,
                        AlbumSales = releaseStreams * (310.0 / 207.0) / 1500.0,
                        Size = new Size(528, 235 + (25 * ((albumInfo.Result.Tracks.Total.Value)))),
                        ReleaseCardSize = new Size(528, 235 + (25 * ((albumInfo.Result.Tracks.Total.Value)))),
                        Location = new Point(2, releaseCardY)
                    };
                    panel.Controls.Add(releaseCard);

                    var trackCardY = 193;
                    var trackNum = 1;
                    var discList = albumInfo2.Data.Discs;
                    for (int discIndex = 0; discIndex < discList.Count; discIndex++)
                    {
                        var trackList = discList[discIndex].Tracks;
                        for (int trackIndex = 0; trackIndex < trackList.Count; trackIndex++)
                        {
                            var trackId = trackList[trackIndex].Uri.Replace("spotify:track:", "");
                            double trackStreams = librespot.GetTrackStreams(discIndex, trackIndex, albumInfo2);
                            // Add track card in the release card
                            TrackCard trackCard = new TrackCard
                            {
                                TrackName = trackList[trackIndex].Name,
                                TrackNumber = trackNum++,
                                TrackStreams = trackStreams,
                                TrackSales = trackStreams * (310.0 / 207.0) / 1500.0,
                                TrackId = trackId,
                                Location = new Point(2, trackCardY += 25)
                            };
                            trackCard.Click += Track_Click;
                            releaseCard.AddTrackCard(trackCard);
                        }
                    }

                    releaseCardY += (260 + (23 * ((albumInfo.Result.Tracks.Total.Value))));
                }
            }

            values[0] = albumsList == null ? 0 : albumsList.Count;
            values[1] = totalReleaseStreams;
            values[2] = totalReleaseStreams * (310.0 / 207.0) / 1500.0;

            return values;
        }

        public double[] GetCompilationsData(string token, string selectedArtistId, BunifuPanel panel)
        {
            double[] values = new double[3];
            var spotify = new SpotifyClient(token);
            LibrespotHelper librespot = new LibrespotHelper();
            var artistInfo = librespot.GetArtistInfo(selectedArtistId);

            // Get summary of streams and sales
            double totalReleaseStreams = 0.0;
            var releaseCardY = 1;
            var compilationsList = artistInfo.Data.Releases.Compilations.Releases;
            if (compilationsList != null)
            {
                for (int compilationIndex = 0; compilationIndex < compilationsList.Count; compilationIndex++)
                {
                    var albumId = compilationsList[compilationIndex].Uri.Replace("spotify:album:", "");
                    var albumInfo = spotify.Albums.Get(albumId);
                    var albumInfo2 = librespot.GetAlbumInfo(albumId);
                    double releaseStreams = librespot.GetReleaseStreams(albumInfo2);
                    totalReleaseStreams += releaseStreams;
                    // Add release card in the panel
                    ReleaseCard releaseCard = new ReleaseCard
                    {
                        AlbumName = albumInfo.Result.Name,
                        AlbumDate = DateTime.ParseExact(albumInfo.Result.ReleaseDate, @"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        AlbumLabel = albumInfo.Result.Label,
                        AlbumUpc = albumInfo.Result.ExternalIds["upc"],
                        AlbumId = albumInfo.Result.Id,
                        AlbumImageUrl = compilationsList[compilationIndex].Cover.Uri,
                        AlbumStreams = releaseStreams,
                        AlbumSales = releaseStreams * (310.0 / 207.0) / 1500.0,
                        Size = new Size(528, 235 + (25 * ((albumInfo.Result.Tracks.Total.Value)))),
                        ReleaseCardSize = new Size(528, 235 + (25 * ((albumInfo.Result.Tracks.Total.Value)))),
                        Location = new Point(2, releaseCardY)
                    };
                    panel.Controls.Add(releaseCard);

                    var trackCardY = 193;
                    var trackNum = 1;
                    var discList = albumInfo2.Data.Discs;
                    for (int discIndex = 0; discIndex < discList.Count; discIndex++)
                    {
                        var trackList = discList[discIndex].Tracks;
                        for (int trackIndex = 0; trackIndex < trackList.Count; trackIndex++)
                        {
                            var trackId = trackList[trackIndex].Uri.Replace("spotify:track:", "");
                            double trackStreams = librespot.GetTrackStreams(discIndex, trackIndex, albumInfo2);
                            // Add track card in the release card
                            TrackCard trackCard = new TrackCard
                            {
                                TrackName = trackList[trackIndex].Name,
                                TrackNumber = trackNum++,
                                TrackStreams = trackStreams,
                                TrackSales = trackStreams * (310.0 / 207.0) / 1500.0,
                                TrackId = trackId,
                                Location = new Point(2, trackCardY += 25)
                            };
                            trackCard.Click += Track_Click;
                            releaseCard.AddTrackCard(trackCard);
                        }
                    }

                    releaseCardY += (260 + (23 * ((albumInfo.Result.Tracks.Total.Value))));
                }
            }

            values[0] = compilationsList == null ? 0 : compilationsList.Count;
            values[1] = totalReleaseStreams;
            values[2] = totalReleaseStreams * (310.0 / 207.0) / 1500.0;

            return values;
        }

        public static void PlayMp3FromUrl(string url, BunifuProgressBar progressBar)
        {
            using (Stream ms = new MemoryStream())
            {
                using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
                {
                    byte[] buffer = new byte[32768];
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                    }
                }

                ms.Position = 0;
                using (WaveStream blockAlignedStream =
                    new BlockAlignReductionStream(
                        WaveFormatConversionStream.CreatePcmStream(
                            new Mp3FileReader(ms))))
                {
                    using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                    {
                        waveOut.Init(blockAlignedStream);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
        }

        private void CP_PreviewButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            PlayMp3FromUrl(trackPreviewUrl + ".mp3", CP_PreviewProgressBar);
            Cursor = Cursors.Default;
        }

        private void AP_PreviewButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            PlayMp3FromUrl(trackPreviewUrl + ".mp3", AP_PreviewProgressBar);
            Cursor = Cursors.Default;
        }

        private void AP_LinkButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(trackSpotifyUrl);
        }

        private void CP_LinkButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(trackSpotifyUrl);
        }

        private void FavoriteToggleSwitch_CheckedChanged(object sender, BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            
        }

        private void FavoriteArtistToggleSwitch_Click(object sender, EventArgs e)
        {
            LibrespotHelper helper = new LibrespotHelper();

            if (FavoriteArtistToggleSwitch.Checked == true)
            {
                FavoriteArtistCard favoriteArtistCard = new FavoriteArtistCard();
                favoriteArtistCard.ArtistId = selectedArtistId;
                var info = helper.GetArtistInsights(selectedArtistId);
                favoriteArtistCard.ArtistImageUrl = info.Data.MainImageUrl;
                FavoriteFlowLayoutPanel.Controls.Add(favoriteArtistCard);
                favoriteArtistCard.Click += FavoriteCardClick;
                favorites.Add(selectedArtistId);
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }
        /*
private void FavoriteButton_Click(object sender, EventArgs e)
{
FavoriteButton.ImageLocation = "C:/Users/TempAdmin2/Documents/SongScout/Assets/favorite.png";

LibrespotHelper helper = new LibrespotHelper();
FavoriteArtistCard favoriteArtistCard = new FavoriteArtistCard();
favoriteArtistCard.ArtistId = selectedArtistId;
var info = helper.GetArtistInsights(selectedArtistId);
favoriteArtistCard.ArtistImageUrl = info.Data.MainImageUrl;
FavoriteFlowLayoutPanel.Controls.Add(favoriteArtistCard);
}*/
    }
}
