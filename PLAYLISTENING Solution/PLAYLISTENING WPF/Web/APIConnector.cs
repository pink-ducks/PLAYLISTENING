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
        public async Task ConnectWithAPI(APIDataGrabber Grabber)
        {
            // CredentialsAuth("id", "secret id")
            CredentialsAuth auth = new CredentialsAuth("2726b49d5bf540e2ab307852eb45a438", "5b453a702f944aaeb40d23077aea2d16");
            Token token = await auth.GetToken();

            SpotifyWebAPI _spotify = new SpotifyWebAPI()
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
            // give access to spotify to APIDataGrabber class
            Grabber.Spotify = _spotify;
        }

    }
}
