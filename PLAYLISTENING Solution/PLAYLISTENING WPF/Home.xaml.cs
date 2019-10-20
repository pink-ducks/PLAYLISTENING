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

namespace PLAYLISTENING_WPF
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            FrontManager Front = FrontManager.Instance;

            Front.loadPlaylistsImages(PlaylistImage1, PlaylistImage2, PlaylistImage3);
            if(Front.blockPlaylistArrows)
            {
                LeftArrowPlaylist.IsEnabled = false;
                LeftArrowPlaylist.Visibility = Visibility.Hidden;
                RightArrowPlaylist.IsEnabled = false;
                RightArrowPlaylist.Visibility = Visibility.Hidden;
            }
        }

        private void RightArrowPlaylistClick(object sender, RoutedEventArgs e)
        {
            FrontManager front = FrontManager.Instance;
           
        }

        private void LeftArrowPlaylistClick(object sender, RoutedEventArgs e)
        {
            FrontManager front = FrontManager.Instance;
        }
    }
}
