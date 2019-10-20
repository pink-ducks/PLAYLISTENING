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
        APIDataGrabber Grabber = APIDataGrabber.Instance; // download data from API
        FrontManager Front = FrontManager.Instance;

        User user = User.Instance;
 

        public MainWindow()
        {
            InitializeComponent();
            //user.createUser("213pado37eomvngbs4vac5qra"); // Paweł
            user.createUser("11132603634"); // Mateusz

            LoadFrontend();
        }

        private async void LoadFrontend()
        {
            try
            {
                await Connector.ConnectWithAPI();
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                if (a != null)
                {
                    MessageBox.Show("You need internet connection to use Playlistening app");
                    System.Windows.Application.Current.Shutdown();
                }
            }

            Connector.GiveSpotifyAccessFor(Grabber);
            Grabber.UploadUserData(user);

            FrontManager Front = FrontManager.Instance;
            Front.loadMainWindowTools(UserName, UserImage, ListViewMenu);
            try
            {
                // change frontend
                Front.updateFrontend(user);
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                Console.WriteLine(a);
            }

            CheckPlaylistArrows();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CheckPlaylistArrows()
        {
            if (Front.blockPlaylistArrows)
            {
                Front.BlockPlaylistArrowsButtons();
            }
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
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }
        private void ButtonMin_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
        
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Home());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new Matus());
                    break;
                default:
                    break;
            }


        }

   
    }

}

