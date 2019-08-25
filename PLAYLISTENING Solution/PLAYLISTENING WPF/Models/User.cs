using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYLISTENING_WPF.Models
{
    public class User
    {
        private string name;
        private string id;
        private string imageURL;
        private ArrayList playlistsIDs;

        public string Id { get => id; set => id = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public ArrayList PlaylistsIDs { get => playlistsIDs; set => playlistsIDs = value; }
        public User(string id) => this.id = id;
    }

    
}
