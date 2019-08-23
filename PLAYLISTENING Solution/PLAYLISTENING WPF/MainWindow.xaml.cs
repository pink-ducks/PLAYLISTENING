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
// 2726b49d5bf540e2ab307852eb45a438 // clientID
// 5b453a702f944aaeb40d23077aea2d16 // secretID
// http://localhost:8888/callback // URI

namespace PLAYLISTENING_WPF
{
    public partial class MainWindow : Window
    {
        private static string _clientId = "2726b49d5bf540e2ab307852eb45a438"; //"";
        private static string _secretId = "5b453a702f944aaeb40d23077aea2d16"; //"";

        public MainWindow()
        {
            HttpGrabber http = new HttpGrabber();
            http.MakeStringGreatAgain();

            InitializeComponent(); // DO NOT DELETE THIS
        }

    }
}
