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
    public class User: Model
    {
        public List<Playlist> Playlists = new List<Playlist>();
        // constructor
        public User(string id) => this.id = id;
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
