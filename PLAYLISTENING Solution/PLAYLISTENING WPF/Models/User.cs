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
        private ArrayList playlistsIDs;
        public ArrayList PlaylistsIDs { get => playlistsIDs; set => playlistsIDs = value; }
        // constructor
        public User(string id) => this.id = id;
        public BitmapImage GetUserImage()
        {
            BitmapImage bitmap = new BitmapImage();
            try
            {
                if(this.id != null)
                {
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
            }

            return bitmap;
        }

    }

    
}
