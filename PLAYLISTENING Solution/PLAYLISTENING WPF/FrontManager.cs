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
        private Image playlistImage1 = new Image();
        private Image playlistImage2 = new Image();
        private Image playlistImage3 = new Image();
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
            this.playlistImage1 = playlistImage1;
            this.playlistImage2 = playlistImage2;
            this.playlistImage3 = playlistImage3;
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
            // create new image to replace old one
            // playlist image 1:
            BitmapImage bitmap = new BitmapImage();
            var image = new Image();
            var fullFilePath = user.Playlists[0].ImageURL;

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();

                playlistImage1.Source = bitmap;

            // playlist image 2:
            BitmapImage bitmap2 = new BitmapImage();
            var image2 = new Image();
            var fullFilePath2 = user.Playlists[1].ImageURL;

            bitmap2.BeginInit();
            bitmap2.UriSource = new Uri(fullFilePath2, UriKind.Absolute);
            bitmap2.EndInit();

            playlistImage2.Source = bitmap2;
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
