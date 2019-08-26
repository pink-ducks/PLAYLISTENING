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
        private string id;
        private string name;
        private string imageURL;
        private ArrayList playlistsIDs;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string ImageURL { get => imageURL; set => imageURL = value; }
        public ArrayList PlaylistsIDs { get => playlistsIDs; set => playlistsIDs = value; }
        // constructor
        public User(string id) => this.id = id;
    }

    
}
