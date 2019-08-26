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
        private SpotifyWebAPI spotify;

        public SpotifyWebAPI Spotify { get => spotify; set => spotify = value; }
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
                PublicProfile profile = spotify.GetPublicProfile(userId);
                userName = profile.DisplayName;
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return userName;
        }
        public ArrayList GetUserPlaylistsIDs(string userId)
        {
            ArrayList playlistsIDs = new ArrayList();
            try {
                Paging<SimplePlaylist> userPlaylists = spotify.GetUserPlaylists(userId);
                userPlaylists.Items.ForEach(playlist => playlistsIDs.Add(playlist.Id));
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }

            return playlistsIDs;
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
            }

            return imageURL;
        }
    }
}
