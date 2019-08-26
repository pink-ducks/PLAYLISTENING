using PLAYLISTENING_WPF.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections;
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
        public void UploadUserData(User user)
        {
            user.Name = this.GetUserName(user.Id);
            user.PlaylistsIDs = this.GetUserPlaylistsIDs(user.Id);
            user.ImageURL = this.GetUserImageURL(user.Id);
        }
        public string GetUserName(string userId)
        {
            string userName = "";

            try
            {
                PublicProfile Profile = _spotify.GetPublicProfile(userId);
                userName = Profile.DisplayName;
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return userName;
        }
        public ArrayList GetUserPlaylistsIDs(string userId)
        {
            ArrayList PlaylistsIDs = new ArrayList();
            try {
                Paging<SimplePlaylist> userPlaylists = _spotify.GetUserPlaylists(userId);
                userPlaylists.Items.ForEach(playlist => PlaylistsIDs.Add(playlist.Id));
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return PlaylistsIDs;
        }

        public string GetUserImageURL(string userId)
        {
            string ImageURL = "";

            try
            {
                PublicProfile Profile = _spotify.GetPublicProfile(userId);
                if (Profile.Images.Count > 0)
                {
                    ImageURL = Profile.Images[0].Url;
                }
                else
                {
                    ImageURL = null;
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return ImageURL;
        }
    }
}
