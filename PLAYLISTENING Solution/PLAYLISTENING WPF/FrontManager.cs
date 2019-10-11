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
        public void updateFrontend(User user)
        {
            updateUsername(user);
            updateUserImage(user);
            updatePlaylistsNames(user);
        }
        public void updatePlaylistsNames(User user)
        {
            if (user.Playlists.Count > 0)
            {
                for (int i = 0; i < user.Playlists.Count; i++)
                {
                    if(i >= 2)
                    {
                        viewMenu.Items.Add(new ListViewItem());
                    }
                    viewMenu.Items[i + 5] = user.Playlists[i].Name;
                }
            }
            else
            {
                viewMenu.Items[5] = null;
                viewMenu.Items[6] = null;
            }
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
