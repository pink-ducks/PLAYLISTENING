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
    class API_Connector
    {
        private static SpotifyWebAPI _spotify;

        public async Task ConnectWithAPI()
        {
            // CredentialsAuth("id", "secret id")
            CredentialsAuth auth = new CredentialsAuth("2726b49d5bf540e2ab307852eb45a438", "5b453a702f944aaeb40d23077aea2d16");
            Token token = await auth.GetToken();

            _spotify = new SpotifyWebAPI()
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
        }

        public string GetTrackName(string TrackID)
        {
            string trackName = "";
            try
            {
                FullTrack track = _spotify.GetTrack(TrackID);
                trackName = track.Name.ToString();
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return trackName;
        }
    }
}
