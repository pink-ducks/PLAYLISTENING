using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web; //Base Namespace
using SpotifyAPI.Web.Enums; //Enums
using SpotifyAPI.Web.Models; //Models for the JSON-responses

namespace PLAYLISTENING_WPF.Web
{
    public class APIConnector
    {
        private string _clientId = "2726b49d5bf540e2ab307852eb45a438";
        private string _clientSecretId = "5b453a702f944aaeb40d23077aea2d16";
        private SpotifyWebAPI _spotify;
        public async Task ConnectWithAPI()
        {
            CredentialsAuth auth = new CredentialsAuth(_clientId, _clientSecretId);
            Token token = await auth.GetToken();

            _spotify = new SpotifyWebAPI()
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
        }
        public void GiveSpotifyAccessFor(APIDataGrabber grabber)
        {
            grabber.Spotify = this._spotify;
        }

    }
}
