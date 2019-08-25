using PLAYLISTENING_WPF.Web;
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
    public partial class MainWindow : Window
    {
        API_Connector Connector = new API_Connector();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            await Connector.ConnectWithAPI();
            string name = Connector.GetTrackName("5N0tw0DWOriyHNr01Wvl6i");
        }
    }
}
