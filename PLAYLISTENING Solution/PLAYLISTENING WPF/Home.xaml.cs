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

            FrontManager Front = FrontManager.Instance;
            User user = User.Instance;

            if (PlaylistIndex + 2 == user.Playlists.Count)
                PlaylistIndex -= user.Playlists.Count - 2;

            Front.updatePlaylistImage(PlaylistIndex, 0, user);
            Front.updatePlaylistImage(PlaylistIndex+1, 1, user);
            Front.updatePlaylistImage(PlaylistIndex+2, 2, user);
        }

        private void LeftArrowPlaylistClick(object sender, RoutedEventArgs e)
        {
            
            PlaylistIndex--;
            if(PlaylistIndex < 0)
            {
                PlaylistIndex++;
            }
            else 
            {
                FrontManager Front = FrontManager.Instance;
                User user = User.Instance;

                if (PlaylistIndex + 2 == user.Playlists.Count)
                    PlaylistIndex -= user.Playlists.Count - 2;

                Front.updatePlaylistImage(PlaylistIndex, 0, user);
                Front.updatePlaylistImage(PlaylistIndex + 1, 1, user);
                Front.updatePlaylistImage(PlaylistIndex + 2, 2, user);
            }
        }
    }
}
