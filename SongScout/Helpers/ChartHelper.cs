using SpotifyAPI;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.Helpers
{
    class ChartHelper
    {
        public string[] dailyTopPlaylistIds =
        {
            "37i9dQZEVXbMDoHDwVN2tF",
            "37i9dQZEVXbNBz9cRCSFkY",
            "37i9dQZEVXbNFJfN1Vw8d9",
            "37i9dQZEVXbLRQDuF5jeBp",
            "37i9dQZEVXbNxXF4SkHj9F",
            "37i9dQZEVXbLZ52XmnySJg",
            "37i9dQZEVXbMnz8KIWsvf9",
            "37i9dQZEVXbKXQ4mDTEBXq",
            "37i9dQZEVXbObFQZ3JLcXt",
            "37i9dQZEVXbK4gjvS1FjPY",
            "37i9dQZEVXbIVYVBNw9D5K",
            "37i9dQZEVXbO3qyFxbkOE1",
            "37i9dQZEVXbMXbN3EUUhlg",
            "37i9dQZEVXbIQnj7RRhdSX",
            "37i9dQZEVXbJiZcmkrIHGU",
            "37i9dQZEVXbIPWwFssbupI"
        };

        public string[] dailyViralPlaylistIds =
        {
            "37i9dQZEVXbLiRSasKsNU9",
            "37i9dQZEVXbJv2Mvelmc3I",
            "37i9dQZEVXbKuaTI1Z1Afx",
            "37i9dQZEVXbM1H8L6Tttw9",
            "37i9dQZEVXbN6kflPvZZn0",
            "37i9dQZEVXbJVi45MafAu0",
            "37i9dQZEVXbKfIuOAZrk7G",
            "37i9dQZEVXbMGnTCc4Vx7v",
            "37i9dQZEVXbMNKGj6aCCDm",
            "37i9dQZEVXbMA8BIYDeMkD",
            "37i9dQZEVXbKpV6RVDTWcZ",
            "37i9dQZEVXbMIJZxwqzod6",
            "37i9dQZEVXbMxjQJh4Um8T",
            "37i9dQZEVXbK4NvPi6Sxit",
            "37i9dQZEVXbJmRv5TqJW16",
            "37i9dQZEVXbO5MSE9RdfN2"
        };

        public string[] weeklyTopPlaylistIds =
        {
            "37i9dQZEVXbNG2KDcFcKOF",
            "37i9dQZEVXbJVKdmjH0pON",
            "37i9dQZEVXbMdvweCgpBAe",
            "37i9dQZEVXbJZGli0rRP3r",
            "37i9dQZEVXbLp5XoPON0wI",
            "37i9dQZEVXbMVY2FDHm6NN",
            "37i9dQZEVXbKqiTGXuCOsB",
            "37i9dQZEVXbJwoKy8qKpHG",
            "37i9dQZEVXbK4fwx2r07XW",
            "37i9dQZEVXbMwmF30ppw50",
            "37i9dQZEVXbK8BKKMArIyl",
            "37i9dQZEVXbNALwC1jxb5m",
            "37i9dQZEVXbIZK8aUquyx8",
            "37i9dQZEVXbJUPkgaWZcWG",
            "37i9dQZEVXbJARRcHjHcAr",
            "37i9dQZEVXbKPTKrnFPD0G"
        };

   /*     public string[] weeklyViralPlaylistIds =
        {

        };*/

        public List<string> GetDailyTopCharts(string artistID, string token)
        {
            List<string> chartPlaylists = new List<string>();
            var spotify = new SpotifyClient(token);

            for (int i = 0; i < 16; i++)
            {
                var playlist = spotify.Playlists.Get(dailyTopPlaylistIds[i]).Result;
                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        for (int j = 0; j < track.Artists.Count; j++)
                        {
                            if (track.Artists[j].Id == artistID)
                                chartPlaylists.Add(dailyTopPlaylistIds[i]);
                        }
                    }
                }
            }

            return chartPlaylists;
        }

        public List<string> GetDailyViralCharts(string artistID, string token)
        {
            List<string> chartPlaylists = new List<string>();
            var spotify = new SpotifyClient(token);

            for (int i = 0; i < 16; i++)
            {
                var playlist = spotify.Playlists.Get(dailyViralPlaylistIds[i]).Result;
                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        for (int j = 0; j < track.Artists.Count; j++)
                        {
                            if (track.Artists[j].Id == artistID)
                                chartPlaylists.Add(dailyViralPlaylistIds[i]);
                        }
                    }
                }
            }

            return chartPlaylists;
        }

        public List<string> GetWeeklyTopCharts(string artistID, string token)
        {
            List<string> chartPlaylists = new List<string>();
            var spotify = new SpotifyClient(token);

            for (int i = 0; i < 16; i++)
            {
                var playlist = spotify.Playlists.Get(weeklyTopPlaylistIds[i]).Result;
                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        for (int j = 0; j < track.Artists.Count; j++)
                        {
                            if (track.Artists[j].Id == artistID)
                                chartPlaylists.Add(weeklyTopPlaylistIds[i]);
                        }
                    }
                }
            }

            return chartPlaylists;
        }

     /*   public List<string> GetWeeklyViralCharts(string artistID, string token)
        {
            List<string> chartPlaylists = new List<string>();
            var spotify = new SpotifyClient(token);

            for (int i = 0; i < 16; i++)
            {
                var playlist = spotify.Playlists.Get(dailyTopPlaylistIds[i]).Result;
                foreach (PlaylistTrack<IPlayableItem> item in playlist.Tracks.Items)
                {
                    if (item.Track is FullTrack track)
                    {
                        for (int j = 0; j < track.Artists.Count; j++)
                        {
                            if (track.Artists[j].Id == artistID)
                                chartPlaylists.Add(dailyTopPlaylistIds[i]);
                        }
                    }
                }
            }

            return chartPlaylists;
        }*/
    }
}
