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
        }
    }
}
