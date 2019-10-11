using PLAYLISTENING_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PLAYLISTENING_WPF
{
    public class FrontManager
    {
        private Label userName = new Label();
        private Image userImage = new Image();
        private ListView viewMenu= new ListView();
        public FrontManager(Label userName, Image userImage, ListView viewMenu)
        {
            this.userName = userName;
            this.userImage = userImage;
            this.viewMenu = viewMenu;
        }
        public void updatePlaylistsNames(User user)
        {
            viewMenu.Items[5] = user.Playlists[0].Name;
            viewMenu.Items[6] = user.Playlists[1].Name;
        }

        public void updateUsername(User user)
        {
            userName.Content = user.Name;
        }

        public void updateUserImage(User user)
        {
            userImage.Source = user.GetUserImage();
        }
    }
}
