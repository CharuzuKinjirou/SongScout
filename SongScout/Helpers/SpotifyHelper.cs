using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongScout.Helpers
{
    class SpotifyHelper
    {
        public string OauthToken { get; set; }

        public async Task GetToken()
        {
            #region Secret
            string CLIENT_ID = "";
            string CLIENT_SECRET = "";
            #endregion

            var config = SpotifyClientConfig.CreateDefault();

            var request = new ClientCredentialsRequest(CLIENT_ID, CLIENT_SECRET);
            var response = await new OAuthClient(config).RequestToken(request);

            OauthToken = response.AccessToken;
        }
    }
}
