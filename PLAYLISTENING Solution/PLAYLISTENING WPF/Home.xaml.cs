using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PLAYLISTENING_WPF.Models;
using PLAYLISTENING_WPF.Web;

namespace PLAYLISTENING_WPF
{
    public partial class Home : UserControl
    {
        static int PlaylistIndex = 0;
        FrontManager Front = FrontManager.Instance;
        public Home()
        {
            InitializeComponent();
            Front.loadPlaylistsImages(PlaylistImage1, PlaylistImage2, PlaylistImage3);
            Front.loadArrowsButtons(LeftArrowPlaylist, RightArrowPlaylist);
        }

        private void RightArrowPlaylistClick(object sender, RoutedEventArgs e)
        {
            PlaylistIndex++;
            UpdatePlaylistsImages();
        }

        private void LeftArrowPlaylistClick(object sender, RoutedEventArgs e)
        {            
            PlaylistIndex--;  
            UpdatePlaylistsImages();
        }

        private void UpdatePlaylistsImages() {

            FrontManager Front = FrontManager.Instance;
            User user = User.Instance;

            if (PlaylistIndex < 0)
            {
                if (PlaylistIndex == -3)
                {
                    PlaylistIndex = user.Playlists.Count - 3;
                }
                switch (PlaylistIndex) //modulo of this variable tell us how many images need to be loaded from the right end of the user.playlists array
                {
                    case -1:
                        Front.updatePlaylistImage(user.Playlists.Count - 1, 0, user);
                        Front.updatePlaylistImage(PlaylistIndex + 1, 1, user);
                        Front.updatePlaylistImage(PlaylistIndex + 2, 2, user);
                        return;

                    case -2:
                        Front.updatePlaylistImage(user.Playlists.Count - 2, 0, user);
                        Front.updatePlaylistImage(user.Playlists.Count - 1, 1, user);
                        Front.updatePlaylistImage(PlaylistIndex + 2, 2, user);
                        return;

                    default:
                        Front.updatePlaylistImage(PlaylistIndex, 0, user);
                        Front.updatePlaylistImage(PlaylistIndex + 1, 1, user);
                        Front.updatePlaylistImage(PlaylistIndex + 2, 2, user);
                        return;
                }
            }
            else {
                if (PlaylistIndex == user.Playlists.Count)
                    PlaylistIndex -= user.Playlists.Count;
                switch (user.Playlists.Count - PlaylistIndex) //the result of this substraction tell us how many images can be loaded, without being out of user.Playlists array
                {   
                    case 2:
                        Front.updatePlaylistImage(PlaylistIndex, 0, user);
                        Front.updatePlaylistImage(PlaylistIndex + 1, 1, user);
                        Front.updatePlaylistImage(0, 2, user);
                        return;               

                    case 1:
                        Front.updatePlaylistImage(PlaylistIndex, 0, user);
                        Front.updatePlaylistImage(0, 1, user);
                        Front.updatePlaylistImage(1, 2, user);
                        return;                        

                    default:
                        Front.updatePlaylistImage(PlaylistIndex, 0, user);
                        Front.updatePlaylistImage(PlaylistIndex + 1, 1, user);
                        Front.updatePlaylistImage(PlaylistIndex + 2, 2, user);
                        return;                       
                }
            }            
        }
    }
}
