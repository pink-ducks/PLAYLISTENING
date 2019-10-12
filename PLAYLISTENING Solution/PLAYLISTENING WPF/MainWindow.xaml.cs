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

        // 11132603634 - Mateusz
        // 213pado37eomvngbs4vac5qra - Paweł

        User User = new User("213pado37eomvngbs4vac5qra"); // app user ("user_id")

        public MainWindow()
        {
            InitializeComponent();
          
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
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
            Grabber.UploadUserData(User);
                      
            FrontManager Front = new FrontManager(UserName, UserImage, ListViewMenu);

            // change frontend
            Front.updateFrontend(User);
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

