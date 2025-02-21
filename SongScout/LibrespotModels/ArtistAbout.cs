using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.LibrespotModels
{
    public class ArtistAbout
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Links
        {
            public string Twitter { get; set; }
            public string Instagram { get; set; }
            public string Facebook { get; set; }
        }

        public class Autobiography
        {
            public string Body { get; set; }
            public Links Links { get; set; }
        }

        public class Image2
        {
            public string Size { get; set; }
            public string Uri { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Image
        {
            public string OriginalId { get; set; }
            public Image2 ArtistImage { get; set; }
        }

        public class Gallery
        {
            public int Total { get; set; }
            public List<Image> Images { get; set; }
            public string GallerySource { get; set; }
        }

        public class Avatar
        {
            public string Size { get; set; }
            public string Uri { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class Data
        {
            public string Name { get; set; }
            public string ArtistUri { get; set; }
            public bool IsVerified { get; set; }
            public Autobiography Autobiography { get; set; }
            public Gallery Gallery { get; set; }
            public Avatar Avatar { get; set; }
            public int MonthlyListeners { get; set; }
            public int GlobalChartPosition { get; set; }
            public int Image2Migration { get; set; }
        }

        public class Root
        {
            public bool Success { get; set; }
            public Data Data { get; set; }
        }
    }
}
