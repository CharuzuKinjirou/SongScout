using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.LibrespotModels
{
    public class ArtistInfo
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Portrait
        {
            public string Uri { get; set; }
        }

        public class Info
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public List<Portrait> Portraits { get; set; }
            public bool Verified { get; set; }
        }

        public class HeaderImage
        {
            public string Image { get; set; }
            public int Offset { get; set; }
        }

        public class Cover
        {
            public string Uri { get; set; }
        }

        public class Track
        {
            public string Uri { get; set; }
            public double Playcount { get; set; }
            public string Name { get; set; }
            public bool Explicit { get; set; }
            public int Popularity { get; set; }
            public int Number { get; set; }
            public int Duration { get; set; }
            public bool Playable { get; set; }
            public List<Artist> Artists { get; set; }
        }

        public class TopTracks
        {
            public List<Track> Tracks { get; set; }
        }

        public class UpcomingConcerts
        {
            public bool InactiveArtist { get; set; }
        }

        public class Artist
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public List<Portrait> Portraits { get; set; }
        }

        public class RelatedArtists
        {
            public List<Artist> Artists { get; set; }
        }

        public class Biography
        {
            public string Text { get; set; }
        }

        public class Disc
        {
            public int Number { get; set; }
            public string Name { get; set; }
            public List<Track> Tracks { get; set; }
        }

        public class Release
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public Cover Cover { get; set; }
        }

        public class Releases
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public Cover Cover { get; set; }
            public int Year { get; set; }
            public int TrackCount { get; set; }
            public List<Disc> Discs { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public Albums Albums { get; set; }
            public Singles Singles { get; set; }
            public AppearsOn AppearsOn { get; set; }
            public Compilations Compilations { get; set; }
        }

        public class Albums
        {
            public List<Releases> Releases { get; set; }
            public int TotalCount { get; set; }
        }

        public class Singles
        {
            public List<Releases> Releases { get; set; }
            public int TotalCount { get; set; }
        }

        public class AppearsOn
        {
            public List<Releases> Releases { get; set; }
            public int TotalCount { get; set; }
        }

        public class Compilations
        {
            public List<Releases> Releases { get; set; }
            public int TotalCount { get; set; }
        }

        public class LatestRelease
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public Cover Cover { get; set; }
            public int Year { get; set; }
            public int TrackCount { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }

        public class Playlist
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public Cover Cover { get; set; }
            public int FollowerCount { get; set; }
        }

        public class PublishedPlaylists
        {
            public List<Playlist> Playlists { get; set; }
        }

        public class MonthlyListeners
        {
            public int ListenerCount { get; set; }
        }

        public class CreatorAbout
        {
            public int MonthlyListeners { get; set; }
        }

        public class Data
        {
            public string Uri { get; set; }
            public Info Info { get; set; }
            public HeaderImage HeaderImage { get; set; }
            public TopTracks TopTracks { get; set; }
            public UpcomingConcerts UpcomingConcerts { get; set; }
            public RelatedArtists RelatedArtists { get; set; }
            public Biography Biography { get; set; }
            public Releases Releases { get; set; }
            public LatestRelease LatestRelease { get; set; }
            public PublishedPlaylists PublishedPlaylists { get; set; }
            public MonthlyListeners MonthlyListeners { get; set; }
            public CreatorAbout CreatorAbout { get; set; }
        }

        public class Root
        {
            public bool Success { get; set; }
            public Data Data { get; set; }
        }
    }
}
