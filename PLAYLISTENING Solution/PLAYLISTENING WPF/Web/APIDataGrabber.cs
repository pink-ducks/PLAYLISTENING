using PLAYLISTENING_WPF.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PLAYLISTENING_WPF.Web
{
    // Singleton pattern
    public sealed class APIDataGrabber
    {
        private SpotifyWebAPI spotify;
        private static readonly APIDataGrabber instance = new APIDataGrabber();
        public SpotifyWebAPI Spotify { get => spotify; set => spotify = value; }
        static APIDataGrabber() { }
        private APIDataGrabber() { }
        public static APIDataGrabber Instance
        {
            get
            {
                return instance;
            }
        }
        public void UploadUserData(User user)
        {
            user.Name = this.GetUserName(user.Id);
            user.Playlists = this.GetUserPlaylists(user.Id);
            user.ImageURL = this.GetUserImageURL(user.Id);
        }
        public string GetUserName(string userId)
        {
            string userName = "";

            try
            {
                PublicProfile profile = spotify.GetPublicProfile(userId);
                userName = profile.DisplayName;
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                Console.WriteLine(a);
            }

            return userName;
        }
        public List<Playlist> GetUserPlaylists(string userId)
        {
            List<Playlist> Playlists = new List<Playlist>();
            try {
                Paging<SimplePlaylist> playlistsIds = spotify.GetUserPlaylists(userId); // download playlists info from spotify
                playlistsIds.Items.ForEach(playlist => Playlists.Add(new Playlist(playlist.Id, playlist.Name, playlist.Images[0].Url)));
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                Console.WriteLine(a);
            }

            return Playlists;
        }

        public string GetUserImageURL(string userId)
        {
            string imageURL = "";

            try
            {
                PublicProfile profile = spotify.GetPublicProfile(userId);
                if (profile.Images.Count > 0)
                {
                    imageURL = profile.Images[0].Url;
                }
                else
                {
                    imageURL = null;
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                Console.WriteLine(a);
            }

            return imageURL;
        }

    }
}
