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
        private string clientId = "2726b49d5bf540e2ab307852eb45a438";
        private string clientSecretId = "5b453a702f944aaeb40d23077aea2d16";
        private SpotifyWebAPI spotify;

        public async Task ConnectWithAPI()
        {
            CredentialsAuth auth = new CredentialsAuth(clientId, clientSecretId);
            Token token = await auth.GetToken();

            spotify = new SpotifyWebAPI()
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
        }
        public void GiveSpotifyAccessFor(APIDataGrabber grabber)
        {
            grabber.Spotify = this.spotify;
        }

    }
}
