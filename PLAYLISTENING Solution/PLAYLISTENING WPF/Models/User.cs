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
        private string _id;
        private string _name;
        private string _imageURL;
        private ArrayList _playlistsIDs;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string ImageURL { get => _imageURL; set => _imageURL = value; }
        public ArrayList PlaylistsIDs { get => _playlistsIDs; set => _playlistsIDs = value; }
        // constructor
        public User(string id) => this._id = id;
    }

    
}
