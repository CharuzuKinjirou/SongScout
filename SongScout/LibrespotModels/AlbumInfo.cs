using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.LibrespotModels
{
    public class AlbumInfo
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Cover
        {
            public string Uri { get; set; }
        }

        public class Image
        {
            public string Uri { get; set; }
        }

        public class Artist
        {
            public string Name { get; set; }
            public string Uri { get; set; }
            public Image Image { get; set; }
        }

        public class Track
        {
            public string Uri { get; set; }
            public double Playcount { get; set; }
            public string Name { get; set; }
            public int Popularity { get; set; }
            public int Number { get; set; }
            public int Duration { get; set; }
            public bool Explicit { get; set; }
            public bool Playable { get; set; }
            public List<Artist> Artists { get; set; }
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
            public int Year { get; set; }
            public int TrackCount { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
        }

        public class Related
        {
            public List<Release> Releases { get; set; }
        }

        public class Additional
        {
            public List<Release> Releases { get; set; }
        }

        public class Data
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public Cover Cover { get; set; }
            public int Year { get; set; }
            public int TrackCount { get; set; }
            public List<Disc> Discs { get; set; }
            public List<string> Copyrights { get; set; }
            public List<Artist> Artists { get; set; }
            public Related Related { get; set; }
            public Additional Additional { get; set; }
            public int Month { get; set; }
            public int Day { get; set; }
            public string Type { get; set; }
            public string Label { get; set; }
        }

        public class Root
        {
            public bool Success { get; set; }
            public Data Data { get; set; }
        }
    }
}
