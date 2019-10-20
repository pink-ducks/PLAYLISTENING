using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PLAYLISTENING_WPF.Models
{
    // Singleton pattern
    public sealed class User: Model
    {
        private static readonly User instance = new User();
        public List<Playlist> Playlists = new List<Playlist>();
        // constructor
        static User() { }
        private User() { }
        public static User Instance
        {
            get
            {
                return instance;
            }
        }
        public void createUser(string id)
        {
            this.Id = id;
        }

        public BitmapImage GetUserImage()
        {
            BitmapImage bitmap = new BitmapImage();
            try
            {
                if(this.id != null)
                {
                    // create new image to replace old one
                    var image = new Image();
                    var fullFilePath = this.ImageURL;

                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                    bitmap.EndInit();
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
                Console.WriteLine(a);
            }

            return bitmap;
        }

    }

    
}
