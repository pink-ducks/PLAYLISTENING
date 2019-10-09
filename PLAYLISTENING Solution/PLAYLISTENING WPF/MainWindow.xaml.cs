using PLAYLISTENING_WPF.Models;
using PLAYLISTENING_WPF.Web;
using System;
using System.Collections;
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
    public partial class MainWindow : Window
    {
        APIConnector Connector = new APIConnector();
        APIDataGrabber Grabber = new APIDataGrabber(); // download data from API
        User User = new User("213pado37eomvngbs4vac5qra"); // app user ("user_id")

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Connector.ConnectWithAPI();

            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(User);
           
            userName.Content = User.Name; // update username

            UserImage.Source = User.GetUserImage(); // update user image
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
        }
        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
    }
    /*
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {

            }

            private void Button_Click_2(object sender, RoutedEventArgs e)
            {

            }

            private void Button_Click_3(object sender, RoutedEventArgs e)
            {

            }

            private void Button_Click_4(object sender, RoutedEventArgs e)
            {

            }

            private void ListViewItem_Selected(object sender, RoutedEventArgs e)
            {

            }

            private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
            {

            }

            private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {

            }
        }*/
}

