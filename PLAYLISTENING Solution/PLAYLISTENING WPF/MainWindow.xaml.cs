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
using PLAYLISTENING_WPF.Web;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace PLAYLISTENING_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            HttpGrabber http = new HttpGrabber();
            http.MakeStringGreatAgain();

            InitializeComponent(); 
        }

    }
}
