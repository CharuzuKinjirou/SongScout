using Newtonsoft.Json;
using SongScout.LibrespotModels;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SongScout.Helpers
{
    public class LibrespotHelper
    {
        public IDictionary<string, DictValue> totalTracks = new Dictionary<string, DictValue>();
        public struct DictValue
        {
            public string trackId;
            public double playcount;
        }

        public List<string> mostStreamedTracksName = new List<string>();
        public List<double> mostStreamedTracksPlaycount = new List<double>();
        public double leadstreams = 0.0;
        public int tracksWith1M = 0;
        public int tracksWith10M = 0;
        public int tracksWith100M = 0;
        public int tracksWith1B = 0;
  

        public ArtistInfo.Root GetArtistInfo(string artistID)
        {
            string jsonResult = string.Empty;
            string url = @"https://api.t4ils.dev/artistInfo?artistid=" + artistID;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    jsonResult = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
            catch
            {
                ErrorForm errorForm = new ErrorForm();
                errorForm.ShowDialog();
            }
            
            ArtistInfo.Root result = JsonConvert.DeserializeObject<ArtistInfo.Root>(jsonResult);
            return result;
        }

        public ArtistInsights.Root GetArtistInsights(string artistID)
        {
            string jsonResult = string.Empty;
            string url = @"https://api.t4ils.dev/artistInsights?artistid=" + artistID;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    jsonResult = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
            catch
            {
                ErrorForm errorForm = new ErrorForm();
                errorForm.ShowDialog();
            }

            ArtistInsights.Root Result = JsonConvert.DeserializeObject<ArtistInsights.Root>(jsonResult);
            return Result;
        }

        public ArtistAbout.Root GetArtistAbout(string artistID)
        {
            string jsonResult = string.Empty;
            string url = @"https://api.t4ils.dev/artistAbout?artistid=" + artistID;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    jsonResult = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
            catch
            {
                ErrorForm errorForm = new ErrorForm();
                errorForm.ShowDialog();
            }

            ArtistAbout.Root Result = JsonConvert.DeserializeObject<ArtistAbout.Root>(jsonResult);
            return Result;
        }

        public AlbumInfo.Root GetAlbumInfo(string albumId)
        {
            string jsonResult = string.Empty;
            string url = @"https://api.t4ils.dev/albumPlayCount?albumid=" + albumId;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    jsonResult = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                }
            }
            catch
            {
                ErrorForm errorForm = new ErrorForm();
                errorForm.ShowDialog();
            }

            AlbumInfo.Root Result = JsonConvert.DeserializeObject<AlbumInfo.Root>(jsonResult);
            return Result;
        }

        public double GetAllTimeStreams(string artistID, string token)
        {
            var tempArtistInfo = GetArtistInfo(artistID);

            var singlesList = tempArtistInfo.Data.Releases.Singles.Releases;
            var albumsList = tempArtistInfo.Data.Releases.Albums.Releases;
            var compilationsList = tempArtistInfo.Data.Releases.Compilations.Releases;
           // var appearancesList = tempArtistInfo.Data.Releases.AppearsOn.Releases;

            double totalStreams = 0.0;

            if (singlesList != null) // getting streams from singles
                for (int index = 0; index < singlesList.Count; index++)
                    GetLeadStreams(singlesList[index].Uri);

            if (albumsList != null) // getting streams from albums
                for (int index = 0; index < albumsList.Count; index++)
                    GetLeadStreams(albumsList[index].Uri);

            if (compilationsList != null) // getting streams from compilations
                for (int index = 0; index < compilationsList.Count; index++)
                    GetLeadStreams(compilationsList[index].Uri);
/*
            if (appearancesList != null) // getting streams from features
                for (int index = 0; index < compilationsList.Count; index++)
                    GetLeadStreams(compilationsList[index].Uri);
*/
            void GetLeadStreams(string releaseURI)
            {
                var releaseID = releaseURI.Replace("spotify:album:", "");
                var tempAlbumInfo = GetAlbumInfo(releaseID);
                var discList = tempAlbumInfo.Data.Discs;

                for (int discIndex = 0; discIndex < discList.Count; discIndex++)
                {
                    var trackList = discList[discIndex].Tracks;
                    for (int trackIndex = 0; trackIndex < trackList.Count; trackIndex++)
                    {
                        var trackId = trackList[trackIndex].Uri.Replace("spotify:track:", "");
                        var spotify = new SpotifyClient(token);
                        var trackIsrc = spotify.Tracks.Get(trackId).Result.ExternalIds["isrc"];     

                        if (!totalTracks.ContainsKey(trackIsrc))
                        {
                            double trackStreams = GetTrackStreams(discIndex, trackIndex, tempAlbumInfo);
                            leadstreams += trackStreams;
                            totalStreams += trackStreams;
                            DictValue trackIDPlusStreams = new DictValue
                            {
                                trackId = trackId,
                                playcount = trackStreams
                            };
                            totalTracks.Add(trackIsrc, trackIDPlusStreams);

                            if (trackStreams >= 1000000000)
                                tracksWith1B++;
                            if (trackStreams >= 100000000)
                                tracksWith100M++;
                            if (trackStreams >= 10000000)
                                tracksWith10M++;
                            if (trackStreams >= 1000000)
                                tracksWith1M++;
                        }
                    }
                }
            }

            return totalStreams;
        }
        
        public double GetReleaseStreams(AlbumInfo.Root albumInfo)
        {
            var discList = albumInfo.Data.Discs;
            double releaseStreams = 0.0;

            for (int discIndex = 0; discIndex < discList.Count; discIndex++)
            {
                var trackList = discList[discIndex].Tracks;
                for (int trackIndex = 0; trackIndex < trackList.Count; trackIndex++)
                {
                    releaseStreams += GetTrackStreams(discIndex, trackIndex, albumInfo);
                }
            }

            return releaseStreams;
        }

        public double GetTrackStreams(int discIndex, int trackIndex, AlbumInfo.Root albumInfo)
        { 
            return albumInfo.Data.Discs[discIndex].Tracks[trackIndex].Playcount;
        }

        public void OrderTracks(IDictionary<string, DictValue> totalTracks, string token)
        {
            var spotify = new SpotifyClient(token);
            var count = 1;
            foreach (var item in totalTracks.OrderByDescending(key => key.Value.playcount))
            {
                string trackName = spotify.Tracks.Get(item.Value.trackId).Result.Name;
                
                if (!mostStreamedTracksName.Contains(trackName) && 
                    !mostStreamedTracksPlaycount.Contains(item.Value.playcount))
                {
                    mostStreamedTracksName.Add(trackName);
                    mostStreamedTracksPlaycount.Add(item.Value.playcount);
                    count++;
                }

                if (count > 5) break;
            }
        }
    }
}
