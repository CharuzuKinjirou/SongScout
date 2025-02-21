using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.LibrespotModels
{
    public class ArtistInsights
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class HeaderImage
        {
            public string Id { get; set; }
            public string Uri { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Links
        {
            public string Twitter { get; set; }
            public string Instagram { get; set; }
            public string Wikipedia { get; set; }
            public string Facebook { get; set; }
        }

        public class Autobiography
        {
            public string Body { get; set; }
            public Links Links { get; set; }
        }

        public class Image
        {
            public string Id { get; set; }
            public string Uri { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Owner
        {
            public string Name { get; set; }
            public string Uri { get; set; }
        }

        public class Entry
        {
            public string Uri { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public Owner Owner { get; set; }
            public int Listeners { get; set; }
        }

        public class Playlists
        {
            public List<Entry> Entries { get; set; }
        }

        public class City
        {
            public string Country { get; set; }
            public string Region { get; set; }
            public string DataCity { get; set; }
            public int Listeners { get; set; }
        }

        public class Data
        {
            public string ArtistGid { get; set; }
            public string Name { get; set; }
            public string MainImageUrl { get; set; }
            public HeaderImage HeaderImage { get; set; }
            public Autobiography Autobiography { get; set; }
            public string Biography { get; set; }
            public List<Image> Images { get; set; }
            public int ImagesCount { get; set; }
            public int GlobalChartPosition { get; set; }
            public int MonthlyListeners { get; set; }
            public int MonthlyListenersDelta { get; set; }
            public int FollowerCount { get; set; }
            public int FollowingCount { get; set; }
            public Playlists Playlists { get; set; }
            public List<City> Cities { get; set; }
        }

        public class Root
        {
            public bool Success { get; set; }
            public Data Data { get; set; }
        }
    }
}
