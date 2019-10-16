using PLAYLISTENING_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PLAYLISTENING_WPF
{
    // Singleton pattern
    public sealed class FrontManager
    {
        private static readonly FrontManager instance = new FrontManager();
        private Label userName = new Label();
        private Image userImage = new Image();
        private Image[] playlistsImages = new Image[3];       
        private ListView viewMenu= new ListView();
        static FrontManager() { } 
        private FrontManager() { }
        public static FrontManager Instance
        {
            get
            {
                return instance;
            }
        }
        public void loadMainWindowTools(Label userName, Image userImage, ListView viewMenu)
        {
            this.userName = userName;
            this.userImage = userImage;
            this.viewMenu = viewMenu;
        }
        public void loadPlaylistsImages(Image playlistImage1, Image playlistImage2, Image playlistImage3)
        {            
            this.playlistsImages[0] = playlistImage1;
            this.playlistsImages[1] = playlistImage2;
            this.playlistsImages[2] = playlistImage3;
        }

        public void updateFrontend(User user)
        {
            updateUsername(user);
            updateUserImage(user);
            updatePlaylistsNames(user);
            updatePlaylistsImages(user);
        }

        private void updatePlaylistsImages(User user)
        {
           // int User_playlist_count_max3 = Math.Min(user.Playlists.Count, 3);
            for(int i=0;i< Math.Min(user.Playlists.Count, 3);i++)
            {
            // create new image to replace old one
            // playlist images:
            BitmapImage bitmap = new BitmapImage();
            var image = new Image();
            var fullFilePath = user.Playlists[i].ImageURL;

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            playlistsImages[i].Source = bitmap;
            }            
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
                    viewMenu.Items[i + 6] = user.Playlists[i].Name; //6 is a magic number + it does not work, when you add items to the viewMenu list
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
