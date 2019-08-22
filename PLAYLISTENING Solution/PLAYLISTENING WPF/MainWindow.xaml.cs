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
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace PLAYLISTENING_WPF
{
    public partial class MainWindow : Window
    {
        public static async void Example()
        {
            SpotifyWebAPI api = new SpotifyWebAPI
            {
                AccessToken = "XX?X?X",
                TokenType = "Bearer"
            };

            PrivateProfile profile = await api.GetPrivateProfileAsync();
            if (!profile.HasError())
            {
                Console.WriteLine(profile.DisplayName);

            }
            else
            {
                Console.WriteLine(profile.Error.Message);
                Console.WriteLine(profile.Error.Status);
            }
        }

        public MainWindow()
        {
            Example();
            InitializeComponent();
        }
    }
}
