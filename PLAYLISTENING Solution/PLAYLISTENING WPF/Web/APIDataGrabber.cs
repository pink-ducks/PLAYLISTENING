using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Web
{
    public class APIDataGrabber
    {
        private SpotifyWebAPI _spotify;

        public SpotifyWebAPI Spotify { get => _spotify; set => _spotify = value; }

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
